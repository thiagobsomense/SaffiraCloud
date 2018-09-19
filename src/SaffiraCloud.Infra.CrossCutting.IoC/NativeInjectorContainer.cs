using Microsoft.Extensions.DependencyInjection;
using SaffiraCloud.ApplicationCore.Interfaces.Repositories;
using SaffiraCloud.ApplicationCore.Interfaces.Services;
using SaffiraCloud.Infra.Data.Context;
using SaffiraCloud.Infra.Data.Repositories;
using SaffiraCloud.Service.Services;

namespace SaffiraCloud.Infra.CrossCutting.IoC
{
    public static class NativeInjectorContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            services.AddScoped<IPaisRepository, PaisRepository>();

            services.AddScoped<IPaisService, PaisService>();
        }
    }
}
