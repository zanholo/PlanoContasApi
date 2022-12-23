using PlanoContas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IServicos
{
    public interface IServicoConta
    {
        public List<ContaPaiFilhoDTO> listarContas();
        public string buscarProximoSequencial(int id);       
        public bool inserirConta(ContaDTO lancamento);
        public bool InserirSubConta(ContaSubDTO lancamento);
        public bool excluirConta(int id);


    }
}
