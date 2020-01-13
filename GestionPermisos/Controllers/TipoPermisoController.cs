using AutoMapper;
using GestionPermisos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionPermisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : BaseApiController<TipoPermiso, TipoPermisoDto>
    {
        public TipoPermisoController(IUnitOfWork unitOf,
            IMapper mapper, 
            ITipoPermisoRepository repository,
            ILogger<BaseApiController<TipoPermiso, TipoPermisoDto>> logger)
            : base(unitOf, mapper, repository, logger)
        {
        }
    }
}