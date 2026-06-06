using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     The model builder extension.
/// </summary>
/// <remarks>
///     Provides extension methods for ModelBuilder to configure the IAM context.
/// </remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     The API configuration rules for the IAM context.
    /// </summary>
    /// <param name="builder">
    ///     The ModelBuilder instance.
    /// </param>
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        // This case is special, because 'EmailAddress' is a value object, not a primitive variable. 
        builder.Entity<User>().OwnsOne(u => u.EmailAddress, email =>
        {
            email.Property(e => e.Value).HasColumnName("EmailAddress").IsRequired();
            email.HasIndex(e => e.Value).IsUnique();
        });
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
    }
}