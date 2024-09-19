using College.API;
using College.Application;
using College.Infrastructure;

namespace College.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Dependency Injection
            builder.Services.AddAPI(builder.Configuration)
                            .AddApplication()
                            .AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "College.API v1"));
            }

            //app.UseSerilogRequestLogging();

            app.UseExceptionHandler();

            app.MapControllers();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin()
            );

            app.Run();

        }
    }
}



//builder.Host.UseSerilog((ctx, lc) =>
//{
//    lc.ReadFrom.Configuration(ctx.Configuration)
//        .Enrich.FromLogContext()
//        .Enrich.WithMachineName()
//        .Enrich.WithProperty(
//            "ApplicationName",
//            typeof(Program).Assembly.GetName().Name
//        )
//        .Enrich.WithProperty("Environment", ctx.HostingEnvironment);
//});

// Add services to the container.



