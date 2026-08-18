using PaymentGateway.Application.DTOs;

namespace PaymentGateway.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<PurchaseResponseDTO>> GetCustomerPurchasesAsync(int customerId);
}
