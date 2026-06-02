using NovaTech.TerraTech.Platform.NotificationManagement.Application.Errors;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Queries;
using NovaTech.TerraTech.Platform.Shared.Application.Patterns;

namespace NovaTech.TerraTech.Platform.NotificationManagement.Application.Services;

public interface INotificationService
{
    Task<Result<Notification, NotificationError>> Handle(CreateNotificationCommand command, CancellationToken cancellationToken = default);
    Task<Result<bool, NotificationError>> Handle(MarkAsReadCommand command, CancellationToken cancellationToken = default);
    Task<IEnumerable<Notification>> Handle(GetNotificationsByProfileQuery query, CancellationToken cancellationToken = default);
    Task<Notification?> Handle(GetNotificationByIdQuery query, CancellationToken cancellationToken = default);
}