using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GestionPermisos.Models
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly IHostingEnvironment _env;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public UnitOfWork(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// Guardar los cambios hechos en la entidad seleccionada.
        /// </summary>
        /// <returns></returns>
        public async Task<ModelOperation> Save()
        {
            try
            {
                var rowsCount = await _context.SaveChangesAsync();
                return new ModelOperation()
                {
                    OperationSuccess = true,
                    Message = "Los Datos fueron guardados correctamente",
                    Data = rowsCount
                };
            }
            catch (DbUpdateException ex)
            {
                var sqlexception = ex.GetBaseException() as SqlException;
                return new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "Ha ocurrido un error al realizar la operación. Verique la información",
                    Data = sqlexception
                };
            }

        }
        public static string HandleExecption(int SqlErrorNumber)
        {
            string message = string.Empty;
            switch (SqlErrorNumber)
            {
                case 547:
                    message = ", El Registro no pudo ser alterado, tiene relación con otros registros del sistema";
                    break;
                case 2601:
                    message = ", El dato suministrado no es valido, por favor verifique la información";
                    break;
                default:
                    message = ", Ha ocurrido un error al realizar la operación. Verique la información";
                    break;
                case 2627:
                    message = ", Ha intentado ingresar un valor duplicado en la tabla";
                    break;
            }

            return message;
        }

    }
}