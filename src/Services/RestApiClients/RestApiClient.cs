using Sky.Models.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sky.Services.RestApiClients
{
    public class RestApiClient : HttpClient, IRestApiClient
    {
        internal RestApiClient(EndpointSettings endpointSettings)
        {
            var uri = new Uri(endpointSettings.ApiEndpoint);

            BaseAddress = new Uri(uri.GetLeftPart(UriPartial.Authority));
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Timeout = new TimeSpan(0, 0, endpointSettings.DefaultTimeout ?? 15);
        }
    }
}
