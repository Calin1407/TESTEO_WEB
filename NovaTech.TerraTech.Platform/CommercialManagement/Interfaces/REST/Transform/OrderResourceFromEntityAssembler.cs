using NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.CommercialManagement.Interfaces.REST.Resources;

namespace NovaTech.TerraTech.Platform.CommercialManagement.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
    {
        return new OrderResource(
            entity.Id,
            entity.ProfileId,
            entity.ProductId,
            entity.ProductName,
            entity.Quantity,
            entity.TotalAmount,
            entity.Status,
            entity.PaymentMethod,
            entity.CreatedAt ?? DateTimeOffset.UtcNow,
            entity.IsSubscription
        );
    }
}