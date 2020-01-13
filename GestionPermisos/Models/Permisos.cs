using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPermisos.Models
{
    public class Permisos : IBaseModel
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }

        [ForeignKey("TipoPermiso")]
        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }

        public virtual TipoPermiso TipoPermiso { get; set; }

    }
}