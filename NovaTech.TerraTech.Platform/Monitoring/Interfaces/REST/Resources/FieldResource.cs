using Swashbuckle.AspNetCore.Annotations;

namespace NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Resources;

[SwaggerSchema(Description = "A Field resource")]
public record FieldResource(
    [SwaggerParameter(Description = "The server-generated ID of the Field")] int Id,
    [SwaggerParameter(Description = "The SoilType provided by SoilType")] string SoilType,
    [SwaggerParameter(Description = "The LocationLatLong from LocationLatLong")] string LocationLatLong);