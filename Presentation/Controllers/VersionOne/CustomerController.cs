using Globus.Core.Common;
using Globus.Core.Dtos;
using Globus.Core.Entities;
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
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OnboardCustomer([FromBody] OnboardCustomerDto request)
            => Ok(await customerService.OnboardCusoter(request));

        [HttpPost, Route("verifyPhoneNumber")]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] VerifyPhoneNumberDto request)
            => Ok(await customerService.VerifyPhoneNumberViaOTP(request));

        [HttpGet, Route("allExistingCustomers")]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<Customer>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<Customer>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AllExistingCustomers()
            => Ok(await customerService.GetAllOnbordedCustomers());
    }
}