using Sky.Services.RestApiClients;

namespace Sky.Services.RestApiClientFactories
{
    public interface IRestApiClientFactory
    {
        IRestApiClient CreateApiClient();
    }
}
