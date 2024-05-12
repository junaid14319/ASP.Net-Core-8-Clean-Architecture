using AspNetCoreCA.Application.Interfaces;
using AspNetCoreCA.Infrastructure.FileManager.Contexts;
using AspNetCoreCA.Infrastructure.FileManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreCA.Infrastructure.FileManager
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddFileManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FileManagerConnection"));
            });
            services.AddScoped<IFileManagerService, FileManagerService>();
            return services;

        }
    }
}