using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using HousePayments.Models;
using Microsoft.AspNetCore.DataProtection;

namespace HousePayments.Services
{
    public class ServicesResidente : IServicesResidentes
    {
        private IRepositoryResidente<Residente> _residenteRepo;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public ServicesResidente(
            IRepositoryResidente<Residente> residenteRepo,
            IDataProtectionProvider dataProtectionProvider
            ) { 
            _residenteRepo = residenteRepo;
            _dataProtectionProvider = dataProtectionProvider;
        }

        public async Task<ResidenteDto> CreateResidente(CreateResidenteDto createResidenteDto)
        {
            try
            {
                var protector = _dataProtectionProvider.CreateProtector("ProtectPass");
                var protectedPass = protector.Protect(createResidenteDto.Password);

                var residente = new Residente
                {
                    Nombre = createResidenteDto.Nombre,
                    Email = createResidenteDto.Email,
                    Password = protectedPass,
                    Telefono = createResidenteDto.Telefono
                };

                await _residenteRepo.CreateResidente(residente);
                await _residenteRepo.Save();

                var residenteDto = new ResidenteDto
                {
                    ResidenteId = residente.ResidenteId,
                    Email = residente.Email,
                    Nombre = residente.Nombre,
                    Telefono = residente.Telefono
                };

                return residenteDto;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public Task<ResidenteDto> DisableResidente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResidenteDto>> GetResidente()
        {
            throw new NotImplementedException();
        }

        public Task<ResidenteDto> GetResidentes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResidenteDto> UpdateResidente(int id, UpdateResidenteDto updateResidenteDto)
        {
            throw new NotImplementedException();
        }
    }
}
