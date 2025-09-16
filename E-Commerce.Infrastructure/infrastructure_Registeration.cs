using E_Commerce.Core.Interfaces;
using E_Commerce.Core.Service;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Repositras;
using E_Commerce.Infrastructure.Repositras.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure
{
    public static class infrastructure_Registeration
    {
        public static IServiceCollection Infrastructureconfiguration(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped(typeof(IGenericRepositray<>), typeof(GenericRepositray<>));
            services.AddDbContext<ApplicationDbContext>(Options =>
              Options.UseSqlServer(
              configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();  
            services.AddSingleton<IImageManagementService, ImageManagementService>();
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            return services;    

        }
    }
}
