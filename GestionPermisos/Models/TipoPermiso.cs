using System.Collections.Generic;

namespace GestionPermisos.Models
{
    public class TipoPermiso : IBaseModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Permisos> Permisos { get; set; }
    }
}