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
    ///     The API configuration table of User.
    /// </summary>
    /// <param name="builder">
    ///     The ModelBuilder instance.
    /// </param>
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        builder.Entity<User>(user =>
        {
            user.ToTable("users");
            user.HasKey(u => u.Id);
            user.Property(u => u.Id).ValueGeneratedOnAdd();

            user.OwnsOne(u => u.EmailAddress, email =>
            {
                email.WithOwner().HasForeignKey("Id");

                email.Property(e => e.Value)
                    .HasColumnName("email_address")
                    .IsRequired()
                    .HasMaxLength(255);
                email.HasIndex(e => e.Value).IsUnique();
            });
            user.Property(u => u.PasswordHash).IsRequired();
            user.Property(u => u.CreatedAt);
            user.Property(u => u.UpdatedAt);
        });
    }
}