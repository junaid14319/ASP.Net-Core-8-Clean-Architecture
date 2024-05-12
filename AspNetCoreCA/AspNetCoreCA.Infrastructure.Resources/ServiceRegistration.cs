using AspNetCoreCA.Application.Interfaces;
using AspNetCoreCA.Infrastructure.Resources.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreCA.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static void AddResourcesInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddSingleton<ITranslator, Translator>();
        }
    }
}
