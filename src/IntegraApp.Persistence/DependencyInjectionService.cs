using IntegraApp.Application.Services;
using IntegraApp.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegraApp.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IntegraAppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("devConnection")));

            services.AddScoped<IDatabaseService, IntegraAppDbContext>();

            return services;
        }
    }
}
