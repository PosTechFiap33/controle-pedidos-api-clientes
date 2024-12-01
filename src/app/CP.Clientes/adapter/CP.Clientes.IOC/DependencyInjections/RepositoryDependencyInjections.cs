using CP.Clientes.Domain.Adapters.Repositories;
using CP.Clientes.Infra;
using CP.Clientes.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Clientes.IOC.DependencyInjections
{
    public static class RepositoryDependencyInjections
	{
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<CPClientesContext>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            return services;
        }
    }
}

