using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HousePayments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authServices.LoginUser(loginDto);

            if (token != null) return Ok(token);

            return BadRequest(new {Error = "Credenciales Incorrectas"});
        }
    }
}
