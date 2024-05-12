﻿using AspNetCoreCA.Application.Interfaces;
using AspNetCoreCA.Application.IRepositories;
using AspNetCoreCA.Infrastructure.Persistence.Contexts;
using AspNetCoreCA.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace AspNetCoreCA.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommDbContext>(options =>
                      options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                  );

            // Registering ECommDbContext as a scoped service
            services.AddScoped<ECommDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<ITranslator, Traslator>();

               services.RegisterRepositories();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var interfaceType = typeof(IGenericRepository<>);
            var interfaces = Assembly.GetAssembly(interfaceType).GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name.ToString()) != null);

            foreach (var item in interfaces)
            {
                var implementation = Assembly.GetAssembly(typeof(GenericRepository<>)).GetTypes()
                    .FirstOrDefault(p => p.GetInterface(item.Name.ToString()) != null);
               // services.AddTransient(item, implementation);
            }
        }
    }
}
