using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Resources;

namespace NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Transform;

public class CreateFieldCommandFromResourceAssembler
{
    public static CreateFieldCommand ToCommandFromResource(CreateFieldResource resource) =>
        new(new SoilType(resource.SoilType), new LocationLatLong(resource.Latitude, resource.Longitude));
}