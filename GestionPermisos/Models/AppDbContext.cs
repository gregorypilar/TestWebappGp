using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionPermisos.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
        {

        }

        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }

    }

    public class Permisos
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }

        [ForeignKey("TipoPermiso")]
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
       
    }

    public class TipoPermiso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}
