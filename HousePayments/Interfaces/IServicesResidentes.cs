using HousePayments.Dto.ResidentesDto;

namespace HousePayments.Interfaces
{
    public interface IServicesResidentes
    {
        Task<IEnumerable<ResidenteDto>> GetResidentes();

        Task<ResidenteDto> GetResidente(int id);

        Task<ResidenteDto> CreateResidente(CreateResidenteDto createResidenteDto);

        Task<ResidenteDto> DisableResidente(int id);

        Task<ResidenteDto> UpdateResidente(int id, UpdateResidenteDto updateResidenteDto);
    }
}
