using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Domain.DTO
{
    public class SubLancamentoInputDTO
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
        /// Id Conta Pai
        /// </summary>
        public int IdContaPai { get; set; }

        /// <summary>
        /// Aceita SubLancamentos
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Aceita SubLancamentos
        /// </summary>
        public bool AceitaLancamentos { get; set; }
    }

    public class SubLancamentoDTO
    {

        public int Id { get; set; }
        /// <summary>
        /// Descrição do Lancamento
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Tipo Conta
        /// </summary>
        public Int16 Tipo { get; set; }

        /// <summary>
        /// Id Conta Pai
        /// </summary>
        public int IdContaPai { get; set; }

        /// <summary>
        /// Aceita SubLancamentos
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Aceita SubLancamentos
        /// </summary>
        public bool AceitaLancamentos { get; set; }
    }
}