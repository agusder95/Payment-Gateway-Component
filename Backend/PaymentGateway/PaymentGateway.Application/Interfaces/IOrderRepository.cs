using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);

    Task<Order?> GetOrderByIdAsync(int id);

    Task UpdateOrderAsync(Order order);

    Task<IEnumerable<Order>> GetApprovedOrdersByCustomerIdAsync(int customerId);
}
