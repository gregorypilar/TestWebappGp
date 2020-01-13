using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace GestionPermisos.Models
{
    public class PermisosDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public string PermisoDescripcion { get; set; }
        public DateTime FechaPermiso { get; set; }
    }


    public class PermisosDtoProfile : Profile
    {
        public PermisosDtoProfile()
        {
            CreateMap<PermisosDto, Permisos>();

            CreateMap<Permisos, PermisosDto>()
                .ForMember(s => s.PermisoDescripcion,
                    m => m.MapFrom((t => t.TipoPermiso.Descripcion)));
        }
    }
}