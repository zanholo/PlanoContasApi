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
        
        public PlanoContasController(ILogger<PlanoContasController> logger, IServicoConta _conta)
        {
            _logger = logger;
        }

        /**
         * Keep Alive para saber se aplicação esta saudável
         */        
        [HttpGet(Name = "Healthy")]
        public bool Healthy()
        {
            return true;
        }                      
        
    }
}