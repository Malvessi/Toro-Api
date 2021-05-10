using Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
    public static partial class DependencyRegister
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            services.Register();
            return services;
        }

        private static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<WorkApiUnitOfWork, WorkApiUnitOfWork>();

            return services;
        }
    }
}
