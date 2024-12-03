using CP.Clientes.Application.UseCases.Clientes;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Clientes.IOC.DependencyInjections
{
    public static class UseCaseDependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICriarClienteUseCase, CriarClienteUseCase>();
            services.AddTransient<IListarTodosClientesUseCase, ListarTodosClientesUseCase>();
        }
    }
}

