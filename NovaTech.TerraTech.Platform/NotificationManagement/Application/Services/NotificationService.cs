using NovaTech.TerraTech.Platform.NotificationManagement.Application.Errors;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Queries;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Repositories;
using NovaTech.TerraTech.Platform.Shared.Application.Patterns;
using NovaTech.TerraTech.Platform.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NovaTech.TerraTech.Platform.NotificationManagement.Application.Services;

public class NotificationService(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork,
    ILogger<NotificationService> logger) : INotificationService
{
    public async Task<Result<Notification, NotificationError>> Handle(CreateNotificationCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var notification = new Notification(command);
            await notificationRepository.AddAsync(notification, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);
            return new Result<Notification, NotificationError>.Success(notification);
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex, "Invalid arguments while creating notification for ProfileId {ProfileId}", command.ProfileId);
            return new Result<Notification, NotificationError>.Failure(NotificationError.InvalidTitle);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error creating notification for ProfileId {ProfileId}", command.ProfileId);
            return new Result<Notification, NotificationError>.Failure(NotificationError.UnexpectedError);
        }
    }

    public async Task<Result<bool, NotificationError>> Handle(MarkAsReadCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var notification = await notificationRepository.FindByIdAsync(command.Id, cancellationToken);
            if (notification == null)
                return new Result<bool, NotificationError>.Failure(NotificationError.NotFound);

            notification.MarkAsRead();
            notificationRepository.Update(notification);
            await unitOfWork.CompleteAsync(cancellationToken);
            return new Result<bool, NotificationError>.Success(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error marking notification {Id} as read", command.Id);
            return new Result<bool, NotificationError>.Failure(NotificationError.UnexpectedError);
        }
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationsByProfileQuery query, CancellationToken cancellationToken = default)
    {
        return await notificationRepository.FindByProfileIdAsync(query.ProfileId, cancellationToken);
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query, CancellationToken cancellationToken = default)
    {
        return await notificationRepository.FindByIdAsync(query.Id, cancellationToken);
    }
}