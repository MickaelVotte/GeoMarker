
using GeoMarker.Application.Common.Interfaces.Authentification;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Common.Interfaces.Services;
using GeoMarker.Domain.Interfaces;
using GeoMarker.Infrastructure.Authentification;
using GeoMarker.Infrastructure.Persistence.Context;
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("GeoMarkerDb"));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            //Interfaces
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();


        }
    }
}
