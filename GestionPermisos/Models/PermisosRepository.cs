namespace GestionPermisos.Models
{
    public class PermisosRepository : GenericRepositoryAsync<Permisos>, IPermisosRepository
    {
        public PermisosRepository(AppDbContext context) : base(context)
        {
        }
    }
}