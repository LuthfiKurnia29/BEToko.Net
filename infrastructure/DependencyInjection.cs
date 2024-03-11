using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.common.interfaces;
using infrastructure.persistence;
using infrastructure.repository;
using infrastructure.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Persistence
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConn"));
            });
            services.AddScoped<IAppDbContext, AppDbContext>();
            
            // Services
            services.AddScoped<IPasswordHash, PasswordServices>();
            services.AddTransient<ITokenService, TokenService>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBarangRepository, BarangRepository>();
        }
    }
}