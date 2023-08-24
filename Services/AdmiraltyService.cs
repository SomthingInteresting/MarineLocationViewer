using System.Net.Http;
using System.Threading.Tasks;

namespace MarineLocationViewer.Services
{
    public class AdmiraltyService
    {
        private readonly string _apiKey;
        private const string BaseUrl = "https://admiraltyapi.azure-api.net/uk_ship_routeing/v1/wms";

        public AdmiraltyService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> GetShipRouteingData()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }
    }
}
