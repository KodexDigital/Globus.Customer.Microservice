using Globus.Core.Common;
using Globus.External.Service.Responses;
using Globus.External.Service.Routes;
using Globus.External.Service.ServiceHeaders;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Globus.External.Service.Services
{
    public class GoldService : IGoldService
    {
        private readonly IConfiguration config;
		readonly HttpClient client;
		public GoldService(IConfiguration config)
		{
            this.config = config;
			client = new HttpClient();

			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add(DefaultRequestHeaders.RapidAPIKey, config.GetSection("RapidApi:RapidAPIKey").Value);
			client.DefaultRequestHeaders.Add(DefaultRequestHeaders.RapidAPIHost, config.GetSection("RapidApi:RapidAPIHost").Value);
		}

		public async Task<ResponseModel<GoldLivePriceResponse>> GetGoldPriceLive()
        {
			
			var baseUrl = config.GetSection("RapidApi:BaseUrl").Value;
			string url = string.Concat(baseUrl, ServiceRoutes.GoldLivePrice);

			var response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var res = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<GoldLivePriceResponse>(res);
				return new ResponseModel<GoldLivePriceResponse>
                {
                    Status = true,
                    Message = "Record Found",
                    Data = new GoldLivePriceResponse
                    {
						Gold = result.Gold,
						Silver = result.Silver
                    }
				};
            }

			return new ResponseModel<GoldLivePriceResponse>
			{
				Status = false,
				Message = "No Record Found",
				Data = null
			};
		}
    }
}
