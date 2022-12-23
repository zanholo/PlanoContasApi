using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.Entidade
{
    public  class ContaEntidade
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Codigo { get; set; }
        public Int16 Tipo { get; set; }
        public int IdPai { get; set; }
        public bool Ativo { get; set; }
        public bool AceitaLancamentos{ get; set; }
    }
}
