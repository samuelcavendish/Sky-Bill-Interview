using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;
using Sky.Models.Configuration;
using System;
using Xunit;

namespace UnitTests.ConfigurationTests
{
    public class ConfigurationTest
    {
        private readonly Action<IServiceCollection> _configureServices;
        private readonly ServiceCollection serviceCollection;
        private IServiceProvider container;
        public ConfigurationTest()
        {
            serviceCollection = new ServiceCollection();
            _configureServices = new Startup().ConfigureServices;
            _configureServices(serviceCollection);
        }

        [Fact]
        //Validate the IOptions are being populated correctly
        //since these values are used in other tests
        public void EndpointConfigValues_Valid()
        {
            container = serviceCollection.BuildServiceProvider();

            var options = container.GetService<IOptions<EndpointSettings>>();

            Assert.NotNull(options);
            Assert.NotNull(options.Value);

            Assert.True(!String.IsNullOrWhiteSpace(options.Value.ApiEndpoint));
            Assert.True(options.Value.DefaultTimeout.HasValue);

            Assert.True(options.Value.ApiEndpoint == "http://safe-plains-5453.herokuapp.com/");
            Assert.True(options.Value.DefaultTimeout == 8);
        }

        [Fact]
        //Validate the IOptions are being populated correctly
        //since these values are used in other tests
        public void LoggingConfigValues_Valid()
        {
            container = serviceCollection.BuildServiceProvider();

            var options = container.GetService<IOptions<LogSettings>>();

            Assert.NotNull(options);
            Assert.NotNull(options.Value);

            Assert.True(!String.IsNullOrWhiteSpace(options.Value.LogDirectory));
            Assert.True(!String.IsNullOrWhiteSpace(options.Value.LogFileName));

            Assert.True(options.Value.LogDirectory == "../TestLogDirectory");
            Assert.True(options.Value.LogFileName == "TestLogFile.txt");
        }
    }
}
