using CP.Clientes.Domain.Adapters.Repositories;
using CP.Clientes.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Clientes.Infra.Configuration
{
    public static class DependencyInjectionConfiguration
    {

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<CP.ClientesContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            return services;
        }

    }
}

