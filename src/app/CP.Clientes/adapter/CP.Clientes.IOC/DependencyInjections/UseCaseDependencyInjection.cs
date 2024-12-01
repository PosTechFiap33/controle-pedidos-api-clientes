using CP.Clientes.Application.UseCases.Clientes;
using CP.Clientes.Application.UseCases.Pedidos;
using CP.Clientes.Application.UseCases.Produtos;
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

