using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sky.Models.Configuration;
using Sky.Services;

namespace UnitTests
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // Set up application services
        public void ConfigureServices(IServiceCollection services)
        {
            //Add the default DI. Items can be overridden in the tests if required
            services.AddOptions();
            services.Configure<EndpointSettings>(Configuration.GetSection("EndpointSettings"));
            services.Configure<LogSettings>(Configuration.GetSection("LogSettings"));

            services.AddSkyServices();
        }
    }
}
