public static OrderResource ToResourceFromEntity(Order order)
{
    return new OrderResource(
        order.Id,
        order.ProfileId,
        order.ProductId,
        order.ProductName,
        order.Quantity,
        order.TotalAmount,  // Ahora es decimal directamente
        order.Status,
        order.PaymentMethod,
        order.CreatedAt ?? DateTimeOffset.Now,
        order.IsSubscription
    );
}