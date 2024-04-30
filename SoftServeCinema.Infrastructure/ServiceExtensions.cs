using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoftServeCinema.Core.Interfaces;
using SoftServeCinema.Infrastructure.Data;
using SoftServeCinema.Infrastructure.Repositories;

namespace SoftServeCinema.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CinemaDbContext>(x =>
                x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IGuidRepository<>), typeof(GuidRepository<>));
        }

    }
}
