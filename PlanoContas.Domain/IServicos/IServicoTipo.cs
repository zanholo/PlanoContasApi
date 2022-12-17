using PlanoContas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.IServicos
{
    public interface IServicoTipo
    {
        public List<TipoDTO> listarTipos();

        public bool inserirTipo(TipoDTO tipo);
    }
}
