using PlanoContas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IServicos
{
    public interface IServicoLancamento
    {
        public List<LancamentoDTO> listarLancamentos();

        public string buscarProximoSequencial(int id);

        public bool inserirLancamento(LancamentoDTO lancamento);
        public bool inserirsubLancamento(SubLancamentoDTO lancamento);
        
    }
}
