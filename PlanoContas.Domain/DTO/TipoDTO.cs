using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanoContas.Domain.DTO
{

    public class TipoInputDTO
    {
        [Required]
        public string Descricao { get; set; }
    }

    public  class TipoDTO
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }  
    }
}
