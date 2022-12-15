using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IServicos
{
    public interface ILancamentos
    {
        public List<string> listarLancamentos();
    }
}
