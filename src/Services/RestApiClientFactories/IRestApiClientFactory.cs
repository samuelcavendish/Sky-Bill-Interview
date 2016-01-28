using Microsoft.Extensions.OptionsModel;
using Sky.Models;
using Sky.Services.RestApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Services.RestApiClientFactories
{
    public interface IRestApiClientFactory
    {
        IRestApiClient CreateApiClient();
    }
}
