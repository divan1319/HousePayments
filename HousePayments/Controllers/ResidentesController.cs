using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ResidenteDto>> Create(CreateResidenteDto createResidenteDto) {

            var residenteDto = await _servicesResidentes.CreateResidente(createResidenteDto);

            return residenteDto == null ? new StatusCodeResult(503) : Ok(residenteDto);
        }

        [HttpPut("disable-residente/{id}")]
        public async Task<ActionResult<ResidenteDto>> DisableRes(int id)
        {
            var resDto = await _servicesResidentes.DisableResidente(id);

            return resDto == null ? new StatusCodeResult(503) : Ok(resDto);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResidenteDto>> GetRes(int id) {
            var resDto = await _servicesResidentes.GetResidente(id);

            return resDto == null ? NotFound() : Ok(resDto);
        }

        [HttpGet]
        public async Task<IEnumerable<ResidenteDto>> GetResidentes() => await _servicesResidentes.GetResidentes();


        [HttpPut("{id}")]
        public async Task<ActionResult<ResidenteDto>> UpdateRes(int id, UpdateResidenteDto updateResidenteDto)
        {
            var res = await _servicesResidentes.UpdateResidente(id, updateResidenteDto);

            return res == null ? NotFound() : Ok(res);
        }
    }
}
