using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Entidade;

namespace PlanoContas.Infraestructure.Ioc
{
    public class ContaContexto : DbContext
    {
        public ContaContexto(DbContextOptions<ContaContexto> options)
        : base(options)
        {
        }

        public DbSet<ContaEntidade> TodasContas { get; set; } = null!;
    }
}
