using APB.API.ESCALAS_MARITIMAS.Dtos;
using APB.API.ESCALAS_MARITIMAS.Repositories;
using APB.ARQ.APIBASE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace APB.API.ESCALAS_MARITIMAS.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EscalasMaritimasController : ApbControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EscalasMaritimasController> _logger;

        public EscalasMaritimasController(IConfiguration config, ILogger<EscalasMaritimasController> logger)
        {
            _config = config;
            _logger = logger;
        }

        private EscalasMaritimasRepository _sostratRepository => new EscalasMaritimasRepository(_config, LANG);

        /// <summary>
        /// Obtener lista de Escalas Marítimas
        /// </summary>
        /// <remarks>
        /// Ejemplo de llamada:
        ///
        ///     GET /api/EscalasMaritimas/GetData
        ///
        /// </remarks>
        /// <param name="escalaMaritimaInputDto"></param>
        /// <returns> Lista de Escalas Marítimas</returns>
        /// <response code="200">Devuelve la Lista de Escalas Marítimas.</response>
        /// <response code="401">No autorizado.</response>
        /// <response code="404">No encontrado.</response>
        /// <response code="500">Error en servidor.</response>
        [Authorize()]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetData", Name = "GetData")]
        [MapToApiVersion("1")]
        public ActionResult<IQueryable<EscalaMaritimaOutputDto>> GetData([FromQuery] EscalaMaritimaInputDto escalaMaritimaInputDto)
        {
            var values = ValidateEscalaMaritimaInputDtoValues(escalaMaritimaInputDto);

            if (!values.isValid)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var res = (escalaMaritimaInputDto.PageNumber != null && escalaMaritimaInputDto.PageSize != null && escalaMaritimaInputDto.PageNumber > 0 && escalaMaritimaInputDto.PageSize > 0)
                ? _sostratRepository.GetPagedResult(values.emInput).Result.AsQueryable()
                : _sostratRepository.GetData(values.emInput).Result;

            if (res.Any())
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        private (EscalaMaritimaInputDto emInput, bool isValid) ValidateEscalaMaritimaInputDtoValues(EscalaMaritimaInputDto escalaMaritimaInputDto)
        {
            if ((escalaMaritimaInputDto.ConEstado != null && escalaMaritimaInputDto.Estados == null) || (escalaMaritimaInputDto.ConEstado == null && escalaMaritimaInputDto.Estados != null))
            {
                return (null, false);
            }

            if ((escalaMaritimaInputDto.PageNumber != null && escalaMaritimaInputDto.PageSize == null) ||
               (escalaMaritimaInputDto.PageNumber == null && escalaMaritimaInputDto.PageSize != null) ||
               (escalaMaritimaInputDto.PageNumber != null && escalaMaritimaInputDto.PageNumber <= 0) ||
               (escalaMaritimaInputDto.PageSize != null && escalaMaritimaInputDto.PageSize <= 0))
            {
                return (null, false);
            }

            return (escalaMaritimaInputDto, true);
        }
    }
}