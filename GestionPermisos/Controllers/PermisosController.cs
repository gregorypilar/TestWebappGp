using AutoMapper;
using GestionPermisos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionPermisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : BaseApiController<Permisos, PermisosDto>
    {
        public PermisosController(IUnitOfWork unitOf,
            IMapper mapper,
            IPermisosRepository repository,
            ILogger<BaseApiController<Permisos, PermisosDto>> logger)
            : base(unitOf, mapper, repository, logger)
        {
        }
    }
}