using System.Text.Json.Serialization;
using CP.Clientes.Api.Middleware;
using CP.Clientes.IOC.DependencyInjections;
using CP.Clientes.Infra.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CP.Clientes.Api.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
                options.Filters.Add<CustomModelStateValidationFilter>()
            ).AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddDatabaseConfiguration(configuration);

            services.RegisterRepositories();

            services.RegisterServices();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddCors(option =>
            {
                option.AddPolicy("Total",
                    builder =>
                      builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader()
                    );
            });

            return services;
        }
    }
}