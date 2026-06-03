using NovaTech.TerraTech.Platform.Shared.Domain.Model;

namespace NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;

public partial class Notification : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}