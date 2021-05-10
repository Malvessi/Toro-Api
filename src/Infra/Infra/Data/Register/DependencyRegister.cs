using Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data.Register
{
    public static partial class DependencyRegister
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Register(configuration);
            return services;
        }

        private static IServiceCollection Register(this IServiceCollection services, IConfiguration config)
        {
            var rdsCredential = Secrets.GetSecret<RdsCredential>(config.GetSection("Program:SecretsConfig:SecretMySQL").Value);
            string connectionString = $"Server={rdsCredential.Host};Port={rdsCredential.Port};Database={rdsCredential.DbName};Uid={rdsCredential.Username};Pwd={rdsCredential.Password};";

            services.AddDbContext<WorkApiDbContext>(options => options.UseMySQL(connectionString));
            services.AddScoped<WorkApiUnitOfWork, WorkApiUnitOfWork>();

            return services;
        }
    }
}
