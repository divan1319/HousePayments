namespace HousePayments.Interfaces
{
    public interface IAuthRepository<TEntity>
    {
        Task<TEntity> GetEmail(string email);
    }
}
