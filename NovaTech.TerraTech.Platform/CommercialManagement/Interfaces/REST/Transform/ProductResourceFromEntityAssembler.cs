using NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.CommercialManagement.Interfaces.REST.Resources;

namespace NovaTech.TerraTech.Platform.CommercialManagement.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Price.Amount,
            entity.Type,
            entity.ImageUrl
        );
    }
}