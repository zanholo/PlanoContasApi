using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Entidade;

namespace PlanoContas.Infraestructure.Ioc
{
    public class LancamentoContexto : DbContext
    {
        public LancamentoContexto(DbContextOptions<LancamentoContexto> options)
        : base(options)
        {
        }

        public DbSet<LancamentoEntidade> TodosLancamentos { get; set; } = null!;
    }
}
