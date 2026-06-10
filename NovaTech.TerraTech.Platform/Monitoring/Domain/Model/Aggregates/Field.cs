using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Commands;

namespace NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;

public partial class Field
{
    protected Field()
    {
        SoilType = null!;
        LocationLatLong = null!;
    }

    public Field(CreateFieldCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        SoilType = command.SoilType;
        LocationLatLong = command.LocationLatLong;
    }
    
    public int Id { get; private set; }
    
    public SoilType SoilType { get; private set; }
    
    public LocationLatLong LocationLatLong { get; private set; }
}