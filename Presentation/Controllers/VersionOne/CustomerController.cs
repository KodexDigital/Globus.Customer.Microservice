using Globus.Core.Common;
using Globus.Core.Common.Responses;
using Globus.Core.Dtos;
using Globus.Service.Declarations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace Presentation.Controllers.VersionOne
{
    [Produces(MediaTypeNames.Application.Json)]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost, Route("onboardCustomer")]
        [ProducesResponseType(typeof(ResponseModel<OnboardCustomerResponse>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OnboardCustomer([FromBody] OnboardCustomerDto request)
            => Ok(await customerService.OnboardCusoter(request));
    }
}
