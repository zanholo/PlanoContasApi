using Microsoft.EntityFrameworkCore;
using PlanoContas.Domain.Entidade;

namespace PlanoContas.Infraestructure.Ioc
{
    public class TipoContexto : DbContext
    {
        public TipoContexto(DbContextOptions<TipoContexto> options)
        : base(options)
        {
        }

        public DbSet<TipoEntidade> TodosTipos { get; set; } = null!;
    }
}
