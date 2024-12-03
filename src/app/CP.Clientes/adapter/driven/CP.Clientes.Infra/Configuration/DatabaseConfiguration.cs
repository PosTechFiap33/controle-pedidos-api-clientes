using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace CP.Clientes.Infra.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionEnv = "DbConnection";
            var connectionString = Environment.GetEnvironmentVariable(connectionEnv) ?? configuration[connectionEnv];
            services.AddDbContext<CPClientesContext>(options => options.UseNpgsql(connectionString));
            return services;
        }

        public static void ConfigureMigrationDatabase(this IServiceProvider services)
        {
            try
            {
                var dbContext = services.GetRequiredService<CPClientesContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<CPClientesContext>>();
                logger.LogError(ex, "Ocorreu um erro ao executar a migration do banco de dados!");
            }
        }
    }
}