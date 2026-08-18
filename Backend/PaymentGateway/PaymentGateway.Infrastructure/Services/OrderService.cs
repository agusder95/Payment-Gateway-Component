using PaymentGateway.Application.DTOs;
using PaymentGateway.Application.Interfaces;

namespace PaymentGateway.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<PurchaseResponseDTO>> GetCustomerPurchasesAsync(int customerId)
    {
        var orders = await _orderRepository.GetApprovedOrdersByCustomerIdAsync(customerId);

        // Mapeo DTO
        return orders.Select(o => new PurchaseResponseDTO
        {
            OrderId = o.IdOrder,
            CreatedAt = o.DatePurchase,
            Items = o
                .OrderItems.Select(item => new PurchasedItemDTO
                {
                    ProductName = item.ProductName,
                    // Simulamos un link de descarga temporal
                    DownloadUrl =
                        $"https://api.tu-reserva.com/downloads/{item.IdOrderItem}?token=temp",
                })
                .ToList(),
        });
    }
}
