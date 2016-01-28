using Rhino.Mocks;
using Sky.Services.RestApiClientFactories;
using Sky.Services.RestApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTests.Utility
{
    public static class MockFactoryCreator
    {
        public static IRestApiClientFactory CreateMockFactoryGetAsyncResponse(HttpResponseMessage response)
        {
            var restClient = MockRepository.GenerateStub<IRestApiClient>();
            restClient.Stub(x => x.GetAsync(String.Empty)).IgnoreArguments()
                .Return(Task.Factory.StartNew(() => response));

            var mockFactory = MockRepository.GenerateStub<IRestApiClientFactory>();
            mockFactory.Stub(x => x.CreateApiClient()).Return(restClient);
            return mockFactory;
        }
    }
}
