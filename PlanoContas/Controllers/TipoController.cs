using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.IServicos;

namespace PlanoContas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TipoController : ControllerBase
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly IServicoTipo tipo;

        public TipoController(ILogger<PlanoContasController> logger, IServicoTipo _tipo)
        {
            _logger = logger;
            tipo = _tipo;
        }

        /**
         * Listar Tipos
         */
        [Route("ListarTipos")]
        [HttpGet]
        public ActionResult<List<TipoDTO>> ListarTipos()
        {
            var result = tipo.listarTipos();

            return Ok(result);
        }


        /**
         * Inserir Tipo
         */
        [Route("InserirTipo")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarTipo(List<TipoInputDTO> listTipoInputDTO)
        {
            try
            {
                foreach (var tipoInputDTO in listTipoInputDTO)
                {
                    TipoDTO tipoDTO = new TipoDTO();
                    tipoDTO.Descricao = tipoInputDTO.Descricao;

                    var result = tipo.inserirTipo(tipoDTO);
                }

                return Ok("Inclusão com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest("Falha na inclusão.");
            }

        }

    }
}
