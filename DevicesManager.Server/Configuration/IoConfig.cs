using DevicesManager.Persistence.Repositories;
using DevicesManager.Services.Interfaces;
using DevicesManager.Services.Services;

namespace DevicesManager.Server.Configuration
{
    public static class IoConfig
    {
        public static IServiceCollection RegisterIoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDeviceQueryService, DeviceQueryService>();
            services.AddScoped<IDeviceCommandService, DeviceCommandService>();
            services.AddScoped<IQueryFrameExecutor, QueryFrameExecutor>();
            return services;
        }
    }
}
