using System;
using System.Threading.Tasks;

namespace GestionPermisos.Models
{
    public interface IUnitOfWork : IDisposable
    {

        Task<ModelOperation> Save();
    }
}