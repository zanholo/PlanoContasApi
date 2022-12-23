using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.DTO
{
    public class ContaInputDTO
    {
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public bool AceitaLancamentos { get; set; }
    }

    public class ContaDTO
    {        
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public bool AceitaLancamentos { get; set; }
        public bool Ativo { get; set; }
    }


    public class ContaPaiFilhoDTO
    {
        public int Id { get; set; }
        
        public string? Descricao { get; set; }
        public Int16 Tipo { get; set; }
        public bool AceitaLancamentos { get; set; }
        public string Codigo { get; set; }
        public bool Ativo { get; set; }
        public int IdPai { get; set; }
        public List<ContaPaiFilhoDTO> listContaFilho { get; set; }
    }
}
