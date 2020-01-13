namespace GestionPermisos.Models
{
    public class TipoPermisoRepository : GenericRepositoryAsync<TipoPermiso>, ITipoPermisoRepository
    {
        public TipoPermisoRepository(AppDbContext context) : base(context)
        {
        }
    }
}