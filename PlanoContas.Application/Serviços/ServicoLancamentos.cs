using Microsoft.Extensions.DependencyInjection;
using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using PlanoContas.Domain.IRepositorios;
using PlanoContas.Domain.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Application.Serviços
{
    public class ServicoLancamentos : IServicoLancamento
    {
        private readonly IServiceProvider _serviceProvider;
        private ILancamentoRepositorio _lancamentoRepositorio;


        public ServicoLancamentos(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _lancamentoRepositorio = serviceProvider.GetRequiredService<ILancamentoRepositorio>();
        }

        /// <summary>
        /// Busca o proximo Sequencial
        /// </summary>
        /// <param name="id">Id do Tipo</param>
        /// <returns>String contendo o proximo sequencial desse tipo </returns>
        public string buscarProximoSequencial(int id)
        {
            var consultaLancamentos = _lancamentoRepositorio.ConsultarLancamentos(id);

            if (consultaLancamentos.Count() == 0)
                return "";
            var lancamentoMaior = consultaLancamentos.OrderByDescending(x => x.Codigo).First();
                        
            return proximoSequencial(lancamentoMaior.Codigo.ToString());            
        }

        /// <summary>
        /// Trazer todos os Lancamentos Gravados
        /// </summary>
        /// <returns>Um List de LancamentoDTO contendo todos os lancamentos</returns>
        public List<LancamentoDTO> listarLancamentos()
        {
            var consultaLancamentos = _lancamentoRepositorio.ConsultarLancamentos(0);

            List<LancamentoDTO> listaLancamentoDto = new List<LancamentoDTO>();

            foreach (var lancamento in consultaLancamentos)
            {
                LancamentoDTO lancamentoDTO = new LancamentoDTO();

                lancamentoDTO.Id = lancamento.Id;
                lancamentoDTO.AceitaLancamentos = lancamento.AceitaLancamentos;
                lancamentoDTO.Descricao = lancamento.Descricao;
                lancamentoDTO.Tipo = lancamento.Tipo;
                //lancamentoDTO.Codigo = lancamento.Codigo;

                listaLancamentoDto.Add(lancamentoDTO);
            }

            return listaLancamentoDto;
        }

        /// <summary>
        /// Insere um lancamento Pai, Conta
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>True, caso inserido com sucesso, false caso ja exista um configurado</returns>
        public bool inserirLancamento(LancamentoDTO lancamento)
        {
            if(validaLancamentoMesmoTipo(lancamento.Tipo)) 
                return false;

            _lancamentoRepositorio.InserirLancamento(lancamento);
            return true;
        }

        /// <summary>
        /// Insere um Lancamento filho, Conta
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        public bool inserirsubLancamento(SubLancamentoDTO lancamento)
        {
            _lancamentoRepositorio.InserirSubLancamento(lancamento);
            return true;
        }

        

        
        /* Tratamentos do Sistema*/

        private string proximoSequencial(string sequencial)
        {

            int freqPontoAparecendo = sequencial.Count(f => (f == '.'));

            switch (freqPontoAparecendo)
            {
                case 0:
                    //valor atual sendo apenas 1
                    //proximo sequencial 1.1
                    return "1.1";
                    break;
                case 1:
                    //valor atual sendo tipo 1.1
                    //proximo sequencial 1.2
                    break;
                case 2:
                    //valor atual sendo tipo 1.1.1
                    //proximo sequencial 1.1.1
                    break;
            }            

            return "";
        }

        public bool validaLancamentoMesmoTipo(int id)
        {
            var consultaLancamentos = _lancamentoRepositorio.ConsultarLancamentos(id);

            return consultaLancamentos.Any() ? true : false;
        }
    }
}
