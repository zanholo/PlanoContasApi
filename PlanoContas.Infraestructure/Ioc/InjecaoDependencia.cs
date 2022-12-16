using Microsoft.Extensions.DependencyInjection;
using PlanoContas.Application.Serviços;
using PlanoContas.Domain.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Infraestructure.Ioc
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection Api(this IServiceCollection services)
        {

            ///Servico
            services = services.AddScoped<IServicoLancamento, ServicoLancamentos>();
            ///Repositorio
            ///
            return services;

        }
    }
}
