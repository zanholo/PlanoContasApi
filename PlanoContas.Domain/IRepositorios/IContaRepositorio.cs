using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IRepositorios
{
    public interface IContaRepositorio
    {
        public List<ContaEntidade> ConsultarContas(int id);

        public bool InserirConta(ContaDTO lancamento);

        public bool InserirSubConta(ContaSubDTO lancamento);

        public bool UpdateConta(ContaEntidade conta);
    }
}
