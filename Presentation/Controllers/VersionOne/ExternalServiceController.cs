using Globus.Core.Common;
using Globus.External.Service.Responses;
using Globus.External.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace Presentation.Controllers.VersionOne
{
    [Produces(MediaTypeNames.Application.Json)]
    public class ExternalServiceController : BaseController
    {
        private readonly IGoldService goldService;

        public ExternalServiceController(IGoldService goldService)
        {
            this.goldService = goldService;
        }

        /// <summary>
        /// This is the endpoint that gets live Gold Price
        /// </summary>
        /// <returns>The prices of gold</returns>
        [HttpGet, Route("goldLivePrice")]
        [ProducesResponseType(typeof(ResponseModel<GoldLivePriceResponse>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<GoldLivePriceResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GoldLivePrice()
            => Ok(await goldService.GetGoldPriceLive());
    }
}
