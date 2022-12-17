using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.Entidade
{
    public  class TipoEntidade
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }
}
