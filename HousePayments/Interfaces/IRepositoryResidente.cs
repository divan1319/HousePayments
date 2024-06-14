namespace HousePayments.Interfaces
{
    public interface IRepositoryResidente<TEntity>
    {
        Task<IEnumerable<TEntity>> GetResidentes();

        Task<TEntity> GetResidente(int id);

        Task CreateResidente(TEntity entity);

        Task<TEntity> GetEmail(string email);

        void DisableResidente(TEntity entity);

        void UpdateResidente(TEntity entity);

        Task<Boolean> Save();
    }
}
