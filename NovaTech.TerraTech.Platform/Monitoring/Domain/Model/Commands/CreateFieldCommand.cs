using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Commands;

public record CreateFieldCommand(SoilType SoilType, LocationLatLong LocationLatLong);