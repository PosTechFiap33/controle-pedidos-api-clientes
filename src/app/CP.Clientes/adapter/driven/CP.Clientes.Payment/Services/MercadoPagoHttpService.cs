using Refit;

namespace CP.Clientes.Payment;

public interface MercadoPagoApi
{
    [Post("/instore/orders/qr/seller/collectors/{userId}/pos/{externalPosId}/qrs")]
    Task<QrCodeMercadoPagoDto> GerarQrCode([Header("Authorization")] string authorization, [Body] PedidoMercadoPagoDto pedido, long userId, string externalPosId);

    [Get("/v1/payments/{pagamentoId}")]
    Task<PagamentoRecebidoMercadoPagoDto> ConsultarPagamento([Header("Authorization")] string authorization, string pagamentoId);
}
