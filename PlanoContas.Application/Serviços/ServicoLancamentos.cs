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

        public bool inserirLancamento(LancamentoDTO lancamento)
        {
            _lancamentoRepositorio.InserirLancamento(lancamento);
            return true;
        }

        public bool inserirsubLancamento(SubLancamentoDTO lancamento)
        {
            _lancamentoRepositorio.InserirSubLancamento(lancamento);
            return true;
        }

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
    }
}
