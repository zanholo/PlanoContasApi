using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.IServicos;
using System.Collections.Generic;

namespace PlanoContas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly IServicoLancamento lancamentos;
        
        public LancamentoController(ILogger<PlanoContasController> logger, IServicoLancamento _lancamentos)
        {
            _logger = logger;
            lancamentos = _lancamentos;
        }                    

        /**
         * Listar Lançamentos cadastrados
         */
        [Route("ListarLancamentos")]
        [HttpGet]        
        public ActionResult<List<LancamentoDTO>> ListarLancamentos()
        {
            var result = lancamentos.listarLancamentos();

            return Ok(result);
        }


        /**
         * Cadastrar Lancamento
         */
        [Route("CadastrarLancamentos")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarLancamentos(LancamentoInputDTO lancamentoInputDTO)
        {
            LancamentoDTO lancamentoDTO = new LancamentoDTO();
            lancamentoDTO.Descricao = lancamentoInputDTO.Descricao;
            lancamentoDTO.AceitaLancamentos = lancamentoInputDTO.AceitaLancamentos;
            lancamentoDTO.Tipo = lancamentoInputDTO.Tipo;

            var result = lancamentos.inserirLancamento(lancamentoDTO);

            var lista = new List<string>();

            return Ok("Inclusão com sucesso.");
        }

        /**
         * Cadastrar Sub Lancamento
         */
        [Route("CadastrarSubLancamentos")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarSubLancamentos(SubLancamentoInputDTO subLancamentoInputDTO)
        {

            SubLancamentoDTO subLancamentoDTO = new SubLancamentoDTO();
            subLancamentoDTO.Descricao = subLancamentoInputDTO.Descricao;
            subLancamentoDTO.AceitaLancamentos = subLancamentoInputDTO.AceitaLancamentos;
            subLancamentoDTO.Tipo = subLancamentoInputDTO.Tipo;

            var result = lancamentos.inserirsubLancamento(subLancamentoDTO);

            return Ok("Inclusão com sucesso.");
        }
    }
}