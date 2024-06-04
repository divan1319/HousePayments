using HousePayments.Dto.ResidentesDto;

namespace HousePayments.Interfaces
{
    public interface IServicesResidentes
    {
        Task<IEnumerable<ResidenteDto>> GetResidente();

        Task<ResidenteDto> GetResidentes(int id);

        Task<ResidenteDto> CreateResidente(CreateResidenteDto createResidenteDto);

        Task<ResidenteDto> DisableResidente(int id);

        Task<ResidenteDto> UpdateResidente(int id, UpdateResidenteDto updateResidenteDto);
    }
}
