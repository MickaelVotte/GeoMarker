using GeoMarker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GeoMarker.Infrastructure.Persistence.Configurations;

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder) 
        { 
                builder.HasKey(g => g.Id);
                builder.Property(g => g.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.Property(g => g.Description)
                    .HasMaxLength(500);
                builder.HasOne(g => g.Owner)
                    .WithMany()
                    .HasForeignKey(g => g.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasMany(u => u.Users)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("GroupMenbers"));
        }
    }

