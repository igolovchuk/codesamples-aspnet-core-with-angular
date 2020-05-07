using Microsoft.Extensions.DependencyInjection;

namespace CoreAngularDemo.API.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => options
                .AddPolicy("CorsPolicy", x => x
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:4200")
                    .WithOrigins("https://CoreAngularDemoclient.azurewebsites.net")
                    .WithOrigins("https://CoreAngularDemoapi.azurewebsites.net")));
        }
    }
}
