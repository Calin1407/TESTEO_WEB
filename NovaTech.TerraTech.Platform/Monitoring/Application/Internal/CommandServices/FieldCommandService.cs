using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Monitoring.Application.Errors;
using NovaTech.TerraTech.Platform.Monitoring.Application.Services;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Repositories;
using NovaTech.TerraTech.Platform.Shared.Application.Model;
using NovaTech.TerraTech.Platform.Shared.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.Monitoring.Application.Internal.CommandServices;

public class FieldCommandService(
    IFieldRepository fieldRepository,
    IUnitOfWork unitOfWork,
    ILogger<FieldCommandService> logger)
    : IFieldCommandService
{
     /// <inheritdoc />
    public async Task<Result<Field>> Handle(CreateFieldCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingSource =
            await fieldRepository.FindBySoilTypeAndLocationLatLongAsync(command.SoilType, command.LocationLatLong,
                cancellationToken);
        if (existingSource != null)
        {
            logger.LogWarning(
                "Duplicate favorite source rejected for SoilType {SoilType} and LocationLatLong {LocationLatLong}",
                command.SoilType,
                command.LocationLatLong);
            return Result<Field>.Failure(
                CreateFieldError.DuplicateField, "A field with the same soil type and location already exists.");
        }

        try
        {
            var Field = new Field(command);
            await fieldRepository.AddAsync(Field, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<Field>.Success(Field);
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex,
                "Invalid arguments while creating favorite source for SoilType {SoilType} and LocationLatLong {LocationLatLong}",
                command.SoilType,
                command.LocationLatLong);
            return Result<Field>.Failure(
                CreateFieldError.UnexpectedError, ex.Message);
        }
        catch (DbUpdateException ex) when (IsDuplicateKeyViolation(ex))
        {
            logger.LogWarning(ex,
                "Duplicate key violation creating favorite source for SoilType {SoilType} and LocationLatLong {LocationLatLong}",
                command.SoilType,
                command.LocationLatLong);
            return Result<Field>.Failure(
                CreateFieldError.DuplicateField, "Database duplicate key violation occurred.");
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex,
                "Database update failed creating favorite source for SoilType {SoilType} and LocationLatLong {LocationLatLong}",
                command.SoilType,
                command.LocationLatLong);
            return Result<Field>.Failure(
                CreateFieldError.UnexpectedError, "Database update failed.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Unexpected error creating favorite source for SoilType {SoilType} and LocationLatLong {LocationLatLong}",
                command.SoilType,
                command.LocationLatLong);
            return Result<Field>.Failure(
                CreateFieldError.UnexpectedError, ex.Message);
        }
    }

    /// <summary>
    /// Determines whether a DbUpdateException represents a duplicate key constraint violation.
    /// </summary>
    /// <param name="exception">The exception to inspect.</param>
    /// <returns>True if the exception is due to a MySQL duplicate key error (code 1062), false otherwise.</returns>
    private static bool IsDuplicateKeyViolation(DbUpdateException exception)
    {
        for (Exception? current = exception; current is not null; current = current.InnerException)
        {
            if (!string.Equals(current.GetType().Name, "MySqlException", StringComparison.Ordinal)) continue;
            var numberProperty = current.GetType().GetProperty("Number");
            if (numberProperty?.PropertyType == typeof(int) &&
                numberProperty.GetValue(current) is int errorCode &&
                errorCode == 1062)
                return true;
        }
        return false;
    }
}