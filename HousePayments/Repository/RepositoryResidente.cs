using HousePayments.Interfaces;
using HousePayments.Models;

namespace HousePayments.Repository
{
    public class RepositoryResidente : IRepositoryResidente<Residente>
    {
        private HousePaymentsContext _context;

        public RepositoryResidente(HousePaymentsContext context) { 
        _context = context;
        }

        public async Task CreateResidente(Residente entity)
        {
            await _context.Residentes.AddAsync(entity);
        }

        public void DisableResidente(Residente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Residente> GetResidente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Residente>> GetResidentes()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateResidente()
        {
            throw new NotImplementedException();
        }
    }
}
