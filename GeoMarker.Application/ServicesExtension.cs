using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using System.Reflection;
using GeoMarker.Application.Common.Behaviors;
using GeoMarker.Application.Services.Authentification;

namespace GeoMarker.Application
{
    public static class ServicesExtensions
    {
        public static void ConfigurationApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());       
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IIdentityService, IdentityService>();


        }
    }
}
