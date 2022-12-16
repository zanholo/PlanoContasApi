using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IRepositorios
{
    public interface ILancamentoRepositorio
    {
        public List<LancamentoEntidade> ConsultarLancamentos(int id);

        public bool InserirLancamento(LancamentoDTO lancamento);

        public bool InserirSubLancamento(SubLancamentoDTO lancamento);
    }
}
