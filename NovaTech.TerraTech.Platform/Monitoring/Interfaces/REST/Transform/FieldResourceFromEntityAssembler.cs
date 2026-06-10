using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Resources;

namespace NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Transform;

public class FieldResourceFromEntityAssembler
{
    public static FieldResource ToResourceFromEntity(Field entity) =>
        new(entity.Id, entity.SoilType.Value, entity.LocationLatLong.ToString());
}