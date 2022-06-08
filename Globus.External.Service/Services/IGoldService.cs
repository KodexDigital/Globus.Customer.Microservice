using Globus.Core.Common;
using Globus.External.Service.Responses;

namespace Globus.External.Service.Services
{
    public interface IGoldService
    {
        Task<ResponseModel<GoldLivePriceResponse>> GetGoldPriceLive();
    }
}
