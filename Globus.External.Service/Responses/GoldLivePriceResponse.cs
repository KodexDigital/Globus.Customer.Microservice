using Newtonsoft.Json;

namespace Globus.External.Service.Responses
{
    public class GoldLivePriceResponse
    {
        [JsonProperty("gold")]
        public double Gold { get; set; }

        [JsonProperty("silver")]
        public double Silver { get; set; }
    }
}
