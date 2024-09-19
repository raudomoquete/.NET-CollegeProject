using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using College.Application.Interfaces.Persistence;
using College.Infrastructure.Repositories;

namespace College.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AppPersistence<DataContext>(configuration);
            return services;
        }

        private static IServiceCollection AppPersistence<TContext>(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();

            return services;
        }
    }
}
