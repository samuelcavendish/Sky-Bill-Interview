using Sky.Models.Bills;
using Sky.Services.LogManagers;
using Sky.Services.RestApiClientFactories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sky.Services.BillManagers
{
    public class BillManager : IBillManager
    {
        private readonly IRestApiClientFactory _restApiClientFactory;
        private readonly ILogManager _logManager;
        public BillManager(IRestApiClientFactory restApiClientFactory, ILogManager logManager)
        {
            _restApiClientFactory = restApiClientFactory;
            _logManager = logManager;
        }

        public async Task<Bill> GetBillAsync()
        {
            try
            {
                using (var restApiClient = _restApiClientFactory.CreateApiClient())
                {
                    return await restApiClient.GetAsync("bill.json")
                        .Result.Content.ReadAsAsync<Bill>();                    
                }
            }
            catch (Exception ex)
            {
                _logManager.LogError("Failed to retrieve bill from endpoint", ex);
            }
            return null;
        }
    }
}
