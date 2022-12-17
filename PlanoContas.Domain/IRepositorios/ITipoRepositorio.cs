using PlanoContas.Domain.DTO;
using PlanoContas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IRepositorios
{
    public interface ITipoRepositorio
    {
        public List<TipoEntidade> ConsultarTipo(int id);

        public bool InserirTipo(TipoDTO tipoDto);        
    }
}
