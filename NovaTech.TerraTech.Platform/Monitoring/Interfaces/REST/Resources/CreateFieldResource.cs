using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Resources;

[SwaggerSchema(Description = "Request payload to create a Field")]
public record CreateFieldResource(
    [Required]
    [SwaggerParameter(Description = "The SoilType (string, max 50 characters)")] string SoilType,
    [Required]
    [SwaggerParameter(Description = "The latitude coordinate (-90 to 90)")] double Latitude,
    [Required]
    [SwaggerParameter(Description = "The longitude coordinate (-180 to 180)")] double Longitude);
