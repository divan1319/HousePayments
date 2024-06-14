using HousePayments.Interfaces;
using HousePayments.Models;
using Microsoft.EntityFrameworkCore;

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
            

            _context.Residentes.Attach(entity);
            _context.Residentes.Entry(entity).Property(e => e.Estado).IsModified = true;
        }

        public async Task<Residente> GetResidente(int id) => await _context.Residentes.FindAsync(id);
        

        public async Task<IEnumerable<Residente>> GetResidentes() => await _context.Residentes.ToListAsync();

        public async Task<Boolean> Save()
        {
            await _context.SaveChangesAsync();

            return true;
        }

        public void UpdateResidente(Residente residente)
        {
            _context.Residentes.Attach(residente);
            _context.Residentes.Entry(residente).State = EntityState.Modified;
        }

        public async Task<Residente> GetEmail(string email) => await _context.Residentes.FirstOrDefaultAsync(x => x.Email == email);
        
        
    }
}
