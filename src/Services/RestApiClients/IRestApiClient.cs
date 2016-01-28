using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sky.Services.RestApiClients
{
    public interface IRestApiClient : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
