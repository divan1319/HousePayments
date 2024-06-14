using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using HousePayments.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HousePayments.Services
{
    public class AuthServices : IAuthServices
    {
        private IRepositoryResidente<Residente> _residenteRepo;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IConfiguration _configuration;

        public AuthServices(
            IRepositoryResidente<Residente> residenteRepo,
            IDataProtectionProvider dataProtectionProvider,
            IConfiguration configuration
            )
        {
            _residenteRepo = residenteRepo;
            _dataProtectionProvider = dataProtectionProvider;
            _configuration = configuration;
        }

        public async Task<string?> LoginUser(LoginDto loginDto)
        {
            var residente = await _residenteRepo.GetEmail(loginDto.Email);

            if(residente != null)
            {
                var protector = _dataProtectionProvider.CreateProtector("ProtectPass");
                var unprotectedPass = protector.Unprotect(residente.Password); // Desencriptar

                if(unprotectedPass == loginDto.Password)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, residente.ResidenteId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddHours(8),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
                        Issuer = _configuration["Jwt:Issuer"]
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return tokenString;
                }

                return null;
            }

            return null;
        }
    }
}
