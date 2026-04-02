using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoMarker.Infrastructure.Persistence.Configurations;

public class UserCongifuration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.HasMany(u => u.Markers)
               .WithOne(m => m.User)
               .HasForeignKey(m => m.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.Property(u => u.Role)
            .HasConversion(v => v.ToString(), v => (UserRole)Enum.Parse(typeof(UserRole), v))
            .IsRequired()
            .HasMaxLength(20)
            .HasDefaultValue(UserRole.User);
    }
}
