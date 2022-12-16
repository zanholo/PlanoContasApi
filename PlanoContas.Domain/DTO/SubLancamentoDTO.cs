using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.DTO
{
    public class SubLancamentoDTO
    {        
        /// <summary>
        /// Descrição do Lancamento
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Tipo Conta
        /// </summary>
        public Int16 Tipo { get; set; }

        /// <summary>
        /// Aceita SubLancamentos
        /// </summary>
        public bool AceitaLancamentos { get; set; }
    }
}
