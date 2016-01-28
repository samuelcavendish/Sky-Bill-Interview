using Microsoft.Extensions.OptionsModel;
using Sky.Models.Configuration;
using Sky.Services.RestApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Services.RestApiClientFactories
{
    public class RestApiClientFactory : IRestApiClientFactory
    {
        private readonly IOptions<EndpointSettings> _endpointSettings;
        public RestApiClientFactory(IOptions<EndpointSettings> endpointSettings)
        {
            _endpointSettings = endpointSettings;
        }

        public IRestApiClient CreateApiClient()
        {
            if (ReferenceEquals(_endpointSettings?.Value?.ApiEndpoint, null))
                throw new Exception("Endpoint not configured: Set the Api Endpoint in the appsettings.");
            return new RestApiClient(_endpointSettings.Value);
        }
    }
}
