using Globus.Core.Common;
using Globus.Core.Dtos;
using Globus.Core.Entities;
using Globus.Service.Declarations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace Presentation.Controllers.VersionOne
{
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]    
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        /// <summary>
        /// This endpoint is for onboarding new customers
        /// </summary>
        /// <param name="request">Expected request payload</param>
        /// <returns>Result of onboarding</returns>
        [HttpPost, Route("onboardCustomer")]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OnboardCustomer([FromBody] OnboardCustomerDto request)
            => Ok(await customerService.OnboardCustomer(request));

        /// <summary>
        /// This is the endpoint used for verifying customer phone number
        /// </summary>
        /// <param name="request">Expected request payload</param>
        /// <returns>Verification result</returns>
        [HttpPost, Route("verifyPhoneNumber")]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] VerifyPhoneNumberDto request)
            => Ok(await customerService.VerifyPhoneNumberViaOTP(request));

        /// <summary>
        /// This is to get all existing customers
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet, Route("allExistingCustomers")]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<Customer>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<IEnumerable<Customer>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AllExistingCustomers()
            => Ok(await customerService.GetAllOnbordedCustomers());
    }
}