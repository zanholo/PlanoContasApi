using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.DTO
{
    public class LancamentoInputDTO
    {
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public bool AceitaLancamentos { get; set; }
    }

    public class LancamentoDTO
    {        
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public bool AceitaLancamentos { get; set; }
    }
}
