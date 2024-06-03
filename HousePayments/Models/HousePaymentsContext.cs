using Microsoft.EntityFrameworkCore;

namespace HousePayments.Models
{
    public class HousePaymentsContext : DbContext
    {
        public HousePaymentsContext(DbContextOptions<HousePaymentsContext> options) : base(options) { }

        public DbSet<Administrador> Administradors { get; set; }

        public DbSet<Casa> Casas {  get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Poligono> Poligonos { get; set; }

        public DbSet<Residente> Residentes { get; set; }

        public DbSet<Senda> Sendas { get; set; }

        public DbSet<SendaPoligono> SendaPoligonos { get; set; }
    }
}
