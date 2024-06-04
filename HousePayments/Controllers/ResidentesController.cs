using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HousePayments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentesController : ControllerBase
    {
        private IServicesResidentes _servicesResidentes;
        public ResidentesController(
            IServicesResidentes servicesResidentes
            ) {
        _servicesResidentes = servicesResidentes;
        }


        [HttpPost]
        public async Task<ActionResult<ResidenteDto>> Create(CreateResidenteDto createResidenteDto) {

            var residenteDto = await _servicesResidentes.CreateResidente(createResidenteDto);

            return residenteDto == null ? new StatusCodeResult(503) : Ok(residenteDto);
        }
    }
}
