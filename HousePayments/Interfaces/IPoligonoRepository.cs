namespace HousePayments.Interfaces
{
    public interface IPoligonoRepository<TEntity>
    {
        Task CreatePoligono(TEntity entity);

        void UpdatePoligono(TEntity entity);

        Task<Boolean> Save();
    }
}
