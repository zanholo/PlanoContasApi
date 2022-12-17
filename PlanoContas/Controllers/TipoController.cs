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
         * Inserir Tipo
         */
        [Route("Inserir Tipo")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarTipo(TipoInputDTO tipoInputDTO)
        {
            TipoDTO tipoDTO = new TipoDTO();
            tipoDTO.Descricao = tipoInputDTO.Descricao;

            var result = tipo.inserirTipo(tipoDTO);

            var lista = new List<string>();

            return Ok("Inclusão com sucesso.");
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
    }
}
