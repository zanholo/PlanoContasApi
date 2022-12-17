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
    public class ContaMapeamento : IEntityTypeConfiguration<ContaEntidade>
    {
        public void Configure(EntityTypeBuilder<ContaEntidade> builder)
        {
            
        }
    }
}
