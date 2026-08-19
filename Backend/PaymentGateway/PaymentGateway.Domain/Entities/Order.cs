using System;
using System.Collections.Generic;

namespace PaymentGateway.Domain.Entities;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DatePurchase { get; set; }

    public string? MercadoPagoPreferenceId { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
