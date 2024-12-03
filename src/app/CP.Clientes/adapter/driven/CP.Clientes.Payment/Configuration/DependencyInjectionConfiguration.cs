using CP.Clientes.Domain.Adapters.Providers;
using CP.Clientes.Payment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CP.Clientes.Payment.Configuration
{
    public static class DependencyInjectionConfiguration
	{
        public static IServiceCollection RegisterPaymentServices(this IServiceCollection services)
        {
            services.AddTransient<IPagamentoProvider, PagamentoMercadoPagoProvider>();
            return services;
        }
    }
}

