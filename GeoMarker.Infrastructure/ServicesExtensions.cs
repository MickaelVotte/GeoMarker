
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Common.Interfaces.Utility;
using GeoMarker.Application.Interfaces;
using GeoMarker.Infrastructure.Authentification;
using GeoMarker.Infrastructure.Persistence.DataContext;
using GeoMarker.Infrastructure.Persistence.Repositories;
using GeoMarker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GeoMarker.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            //Services
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IMarkerRepository, MarkerRepository>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        }
    }
}
