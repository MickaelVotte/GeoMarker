using GeoMarker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoMarker.Infrastructure.Persistence.Configurations
{
    public class MarkerConfiguration : IEntityTypeConfiguration<Marker>
    {
        public void Configure(EntityTypeBuilder<Marker> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(m => m.Description)
                    .HasMaxLength(500);
            builder.Property(m => m.Latitude)
                .HasColumnType("decimal(12, 10)");
            builder.Property(m => m.Longitude)
                .HasColumnType("decimal(12, 10)");
            builder.HasIndex(m => new { m.Latitude, m.Longitude })
                .HasDatabaseName("IX_Markers_Latitude_Longitude");
            builder.HasOne(m => m.User)
                .WithMany(u => u.Markers)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
