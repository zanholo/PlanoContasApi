using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.IServicos;
using System.Collections.Generic;

namespace PlanoContas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ILogger<PlanoContasController> _logger;
        private readonly IServicoConta conta;
        
        public ContaController(ILogger<PlanoContasController> logger, IServicoConta _conta)
        {
            _logger = logger;
            conta = _conta;
        }                    

        /**
         * Listar Lançamentos cadastrados
         */
        [Route("ListaConta")]
        [HttpGet]        
        public ActionResult<List<ContaPaiFilhoDTO>> ListaConta()
        {
            var result = conta.listarContas();

            return Ok(result);
        }


        /**
         * Cadastrar Conta
         */
        [Route("CadastrarConta")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarConta(ContaInputDTO contaimputDTO)
        {
            try
            {
                ContaDTO contaDTO = new ContaDTO();
                contaDTO.Descricao = contaimputDTO.Descricao;
                contaDTO.AceitaLancamentos = contaimputDTO.AceitaLancamentos;
                contaDTO.Tipo = contaimputDTO.Tipo;

                var result = conta.inserirConta(contaDTO);
                
                return Ok("Inclusão com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            

        }

        /**
         * Cadastrar Sub Conta
         */
        [Route("CadastrarSubConta")]
        [HttpPost]
        public ActionResult<List<string>> CadastrarSubConta(ContaSubInputDTO subContaInputDTO)
        {
            try{
                ContaSubDTO subContaDTO = new ContaSubDTO();
                subContaDTO.Descricao = subContaInputDTO.Descricao;
                subContaDTO.AceitaLancamentos = subContaInputDTO.AceitaLancamentos;
                subContaDTO.Tipo = subContaInputDTO.Tipo;
                subContaDTO.IdContaPai = subContaInputDTO.IdContaPai;
                subContaDTO.Codigo = subContaInputDTO.Codigo;

                var result = conta.InserirSubConta(subContaDTO);

                return Ok("Inclusão com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        /**
         * Retornar Proximo Codigo disponível para a Conta
         */
        [Route("RetornarProximoCodigo")]
        [HttpPost]
        public ActionResult<string> ListarProximoCodigoFilhoPor(int idContaPai)
        {
            var result = conta.buscarProximoSequencial(idContaPai);

            if (result.ToString() == "")
                return Ok("Não foram encontrados Contas para esse pai.");

            return Ok(result);
        }
        
    }
}