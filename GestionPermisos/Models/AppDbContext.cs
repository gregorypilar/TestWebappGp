using Microsoft.EntityFrameworkCore;

namespace GestionPermisos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }

    }
}
