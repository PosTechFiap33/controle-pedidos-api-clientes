using CP.Clientes.Domain.Adapters.Providers;
using CP.Clientes.Payment.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CP.Clientes.Payment.Configurations;

public static class RefitConfiguration
{
    public static IServiceCollection ConfigureHttpPayment(this IServiceCollection services)
    {
        services.AddRefitClient<MercadoPagoApi>()
               .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.mercadopago.com"));
        services.AddTransient<IPagamentoProvider, PagamentoMercadoPagoProvider>();
        return services;
    }
}
