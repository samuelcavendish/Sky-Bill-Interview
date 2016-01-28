using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rhino.Mocks;
using Sky.Models.Configuration;
using Sky.Services.BillManagers;
using Sky.Services.LogManagers;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Utility;
using Xunit;

namespace UnitTests.BillTests
{
    public class BillManagerTest
    {
        private readonly Action<IServiceCollection> _configureServices;
        private readonly ServiceCollection serviceCollection;
        private IServiceProvider container;
        public BillManagerTest()
        {
            serviceCollection = new ServiceCollection();
            _configureServices = new Startup().ConfigureServices;
            _configureServices(serviceCollection);
        }

        [Fact]
        public async Task DownloadBill_LiveUrl_ReturnsBill()
        {
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.NotNull(bill.Statement);            
            Assert.NotNull(bill.Package);
            Assert.NotNull(bill.CallCharges);
            Assert.NotNull(bill.SkyStore);
        }

        [Fact]
        public async Task DownloadBill_LiveUrl_DeserialisationValid()
        {
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.True(bill?.Statement?.Period?.From < bill?.Statement?.Period?.To);
            Assert.Equal(bill?.Package?.Subscriptions?.Count(), 3);
            Assert.Equal(bill?.CallCharges?.Calls.Count(), 28);
            Assert.Equal(bill?.SkyStore?.Rentals.Count(), 1);
            Assert.Equal(bill?.SkyStore?.BuyAndKeep.Count(), 2);
        }

        [Fact]
        public async Task DownloadBill_LiveUrl_TotalsAddUp()
        {
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.Equal(bill?.Package?.Subscriptions?.Sum(x => x?.Cost), bill?.Package?.Total);
            Assert.Equal(bill?.CallCharges?.Calls?.Sum(x => x?.Cost), bill?.CallCharges?.Total);
            Assert.Equal((bill?.SkyStore?.Rentals?.Sum(x => x?.Cost) + bill?.SkyStore.BuyAndKeep.Sum(x => x?.Cost)), bill?.SkyStore?.Total);
            Assert.Equal(bill?.Package?.Total + bill?.CallCharges?.Total + bill?.SkyStore?.Total, bill?.Total);
        }

        [Fact]
        public async Task DownloadBill_LocalFileCopy_ReturnsBill()
        {
            JObject localFileCopy = JObject.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"BillTests/bill.json")));
            var mockFactory = MockFactoryCreator.CreateMockFactoryGetAsyncResponse(
                new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(localFileCopy.ToString(), Encoding.UTF8, "text/json") });
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.NotNull(bill.Statement);            
            Assert.NotNull(bill.Package);
            Assert.NotNull(bill.CallCharges);
            Assert.NotNull(bill.SkyStore);
        }

        [Fact]
        public async Task DownloadBill_LocalFileCopy_DeserialisationValid()
        {
            JObject localFileCopy = JObject.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"BillTests/bill.json")));
            var mockFactory = MockFactoryCreator.CreateMockFactoryGetAsyncResponse(
                new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(localFileCopy.ToString(), Encoding.UTF8, "text/json") });
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.True(bill?.Statement?.Period?.From < bill?.Statement?.Period?.To);
            Assert.Equal(bill?.Package?.Subscriptions?.Count(), 3);
            Assert.Equal(bill?.CallCharges?.Calls.Count(), 28);
            Assert.Equal(bill?.SkyStore?.Rentals.Count(), 1);
            Assert.Equal(bill?.SkyStore?.BuyAndKeep.Count(), 2);
        }

        [Fact]
        public async Task DownloadBill_LocalFileCopy_TotalsAddUp()
        {
            JObject localFileCopy = JObject.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"BillTests/bill.json")));
            var mockFactory = MockFactoryCreator.CreateMockFactoryGetAsyncResponse(
                new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(localFileCopy.ToString(), Encoding.UTF8, "text/json") });
            serviceCollection.AddSingleton(x => mockFactory);
            container = serviceCollection.BuildServiceProvider();

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.NotNull(bill);
            Assert.Equal(bill?.Package?.Subscriptions?.Sum(x => x?.Cost), bill?.Package?.Total);
            Assert.Equal(bill?.CallCharges?.Calls?.Sum(x => x?.Cost), bill?.CallCharges?.Total);
            Assert.Equal((bill?.SkyStore?.Rentals?.Sum(x => x?.Cost) + bill?.SkyStore.BuyAndKeep.Sum(x => x?.Cost)), bill?.SkyStore?.Total);
            Assert.Equal(bill?.Package?.Total + bill?.CallCharges?.Total + bill?.SkyStore?.Total, bill?.Total);
        }

        [Fact]
        public async Task DownloadBill_Mock_InvalidJson()
        {
            var mockFactory = MockFactoryCreator.CreateMockFactoryGetAsyncResponse(
                new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent("{ba;}ws}", Encoding.UTF8, "text/json") });
            serviceCollection.AddSingleton(x => mockFactory);

            var logger = MockRepository.GenerateStub<ILogManager>();
            serviceCollection.AddSingleton(x => logger);

            container = serviceCollection.BuildServiceProvider();
            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.Null(bill);
            logger.AssertWasCalled(x => x.LogError(Arg<String>.Is.Equal("Failed to retrieve bill from endpoint"),
                Arg<Exception>.Matches(y => y.GetType() == typeof(JsonReaderException))));
        }

        [Fact]
        public async Task DownloadBill_CannotResolve()
        {
            var logger = MockRepository.GenerateStub<ILogManager>();
            serviceCollection.AddSingleton(x => logger);

            container = serviceCollection.BuildServiceProvider();

            var options = container.GetService<IOptions<EndpointSettings>>();
            options.Value.ApiEndpoint = "http://thisisaurlthatwillreturna404.lll/";

            var billManager = container.GetService<IBillManager>();
            var bill = await billManager.GetBillAsync();

            Assert.Null(bill);

            logger.AssertWasCalled(x => x.LogError(Arg<String>.Is.Equal("Failed to retrieve bill from endpoint"),
                Arg<Exception>.Matches(y => y.ToString().Contains("The remote name could not be resolved"))));
        }
    }
}
