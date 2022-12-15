using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.IServicos;
using System.Collections.Generic;

namespace PlanoContas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlanoContasController : ControllerBase
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly ILancamentos lancamentos;

        public PlanoContasController(ILogger<PlanoContasController> logger, ILancamentos _lancamentos)
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
        public ActionResult<List<string>> ListarLancamentos()
        {
            var result = lancamentos.listarLancamentos();

            var lista = new List<string>(); 

            return Ok(lista);
        }
    }
}