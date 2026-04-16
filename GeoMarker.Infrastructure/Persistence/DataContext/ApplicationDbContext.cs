using GeoMarker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GeoMarker.Application.Common.Interfaces.Persistence;


namespace GeoMarker.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Marker> Markers { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Appliquer toutes les configurations d'entitiés
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
