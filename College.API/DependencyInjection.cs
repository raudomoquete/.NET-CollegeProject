using Microsoft.OpenApi.Models;

namespace College.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddProblemDetails();

            services.AddHttpClient();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ViaroCollege.API", Version = "v1" });
            });

            return services;
        }
    }
}
