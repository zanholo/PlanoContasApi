using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanoContas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Infraestructure.Mapeamento
{
    public class LancamentoMapeamento : IEntityTypeConfiguration<LancamentoEntidade>
    {
        public void Configure(EntityTypeBuilder<LancamentoEntidade> builder)
        {
            
        }
    }
}
