using HousePayments.Dto.ResidentesDto;

namespace HousePayments.Interfaces
{
    public interface IAuthServices
    {
        Task<string> LoginUser(LoginDto loginDto);
        
    }
}
