using NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.Commands;

public record CreateOrderCommand(
    string ProfileId,
    int ProductId,
    int Quantity,
    PaymentMethod PaymentMethod,
    bool IsSubscription = false);