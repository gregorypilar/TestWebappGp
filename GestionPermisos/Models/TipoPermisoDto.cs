using AutoMapper;

namespace GestionPermisos.Models
{
    public class TipoPermisoDto 
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoPermisoDtoProfile : Profile
    {
        public TipoPermisoDtoProfile()
        {
            CreateMap<TipoPermisoDto, TipoPermiso>();

            CreateMap<TipoPermiso, TipoPermisoDto>();
        }
    }
}