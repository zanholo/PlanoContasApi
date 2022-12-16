using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.IServicos;
using System.Collections.Generic;

namespace PlanoContas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlanoContasController : ControllerBase
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly IServicoLancamento lancamentos;

        public PlanoContasController(ILogger<PlanoContasController> logger, IServicoLancamento _lancamentos)
        {
            _logger = logger;
            lancamentos = _lancamentos;
        }

        /**
         * Keep Alive para saber se aplicação esta saudável
         */        
        [HttpGet(Name = "Healthy")]
        public bool Healthy()
        {
            return true;
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
        public ActionResult<List<string>> CadastrarLancamentos(LancamentoDTO lancamento)
        {
            var result = lancamentos.inserirLancamento(lancamento);

            var lista = new List<string>();

            return Ok(lista);
        }

        /**
         * Cadastrar Lancamento
         */
        [Route("CadastrarLancamentos")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarSubLancamentos(SubLancamentoDTO lancamento)
        {
            //var result = lancamentos.inserirLancamento(lancamento);

            var lista = new List<string>();

            return Ok(lista);
        }
    }
}