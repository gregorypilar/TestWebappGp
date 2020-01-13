using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GestionPermisos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionPermisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T, TU> : ControllerBase where T : class, IBaseModel where TU : class, new()
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        internal readonly ILogger<BaseApiController<T, TU>> _Logger;
        private readonly IGenericRepositoryAsync<T> _repository;

        public BaseApiController(IUnitOfWork unitOf,
            IMapper mapper,
            IGenericRepositoryAsync<T> repository,
            ILogger<BaseApiController<T, TU>> logger)
        {
            this._unitOfWork = unitOf;
            this._mapper = mapper;
            this._Logger = logger;
            this._repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            try
            {
                var data = await _repository.GetAll();
                var result = _mapper.Map<List<TU>>(data);
                return Ok(new ModelOperation()
                {
                    OperationSuccess = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _Logger.LogWarning(ex.Message);
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Data = ex.Data,
                    Message = "Ha ocurrido un error inesperado"
                });
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var data = await _repository.ById(id.Value);
                    var result = _mapper.Map<TU>(data);
                    if (data == null)
                    {
                        return Ok(new ModelOperation()
                        {
                            OperationSuccess = false,
                            Message = $"El {nameof(T)} no existe en la base de datos. Verifique la información suministrada"
                        });
                    }
                    else
                    {
                        return Ok(new ModelOperation()
                        {
                            OperationSuccess = true,
                            Data = data
                        });
                    }

                }
                else
                {
                    return Ok(new ModelOperation()
                    {
                        OperationSuccess = false,
                        Message = "Verifique la información suministrada"
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "Ha ocurrido un error inesperado",
                    Data = ex.Data
                });
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TU data)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _record = this._mapper.Map<T>(data);
                    //
                    await _repository.Add(_record);
                    var Operation = await _unitOfWork.Save();
                    if (Operation.OperationSuccess)
                    {
                        return Ok(new ModelOperation()
                        {
                            OperationSuccess = true,
                            Message = $"El {nameof(T)} fue creado de manera exitosa"

                        });
                    }
                    else
                    {

                        if (int.Parse(Operation.Data.ToString()) == 2601)
                        {
                            return Ok(new ModelOperation()
                            {
                                OperationSuccess = false,
                                Message = $"El Id {_record.Id} suministrado ya existe en los registros. Intentelo otra vez con otro."
                            });
                        }

                    }
                }
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "A Ocurrido un error inesperado",
                });
            }
            catch (Exception ex)
            {
                _Logger.LogWarning(ex.Message);
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = ex.Message,
                    Data = ex.Data
                });
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TU data)
        {
            try
            {
                var _record = this._mapper.Map<T>(data);

                if (ModelState.IsValid && _record.Id != 0)
                {
                    await _repository.Update(_record);
                    var Operation = await _unitOfWork.Save();
                    if (Operation.OperationSuccess)
                    {
                        return Ok(new ModelOperation()
                        {
                            OperationSuccess = true,
                            Message = $"El {nameof(T)} ha siado actualizado"

                        });
                    }
                    else
                    {
                        if (int.Parse(Operation.Data.ToString()) == 2601)
                        {
                            return Ok(new ModelOperation()
                            {
                                OperationSuccess = false,
                                Message = $"El Codigo {_record.Id} suministrado ya existe en los registros. Intentelo otra vez con otro."
                            });
                        }
                    }
                }
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "A Ocurrido un error inesperado",
                });
            }
            catch (Exception ex)
            {
                _Logger.LogWarning(ex.Message);
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = ex.Message,
                    Data = ex.Data
                });
            }
        }


        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    T _record = await _repository.ById(id);

                    if (_record == null)
                    {
                        return Ok(new ModelOperation()
                        {
                            OperationSuccess = false,
                            Message = $"El {nameof(T)} no existe en la base de datos"
                        });
                    }
                    else
                    {
                        await _repository.Delete(_record);
                        var operation = await _unitOfWork.Save();
                        if (operation.OperationSuccess)
                        {
                            return Ok(new ModelOperation()
                            {
                                OperationSuccess = true,
                                Message = $"El {nameof(T)} fue eleminado correctamente"
                            });
                        }
                        else
                        {
                            if (int.Parse(operation.Data.ToString()) == 547)
                            {
                                return Ok(new ModelOperation()
                                {
                                    OperationSuccess = false,
                                    Message = $"{nameof(T)} ya tiene relación con otros registros del sistema, por lo tanto no se puede eliminar.",
                                });
                            }
                        }
                    }
                }
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "Verifique la informació suministrada."
                });
            }
            catch (Exception ex)
            {
                return Ok(new ModelOperation()
                {
                    OperationSuccess = false,
                    Message = "Ha ocurrido un error inesperado.",
                    Data = ex.Data
                });
            }
        }

        

    }
}
