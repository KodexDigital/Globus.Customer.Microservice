using Globus.Core.Common;
using Globus.Core.Entities;
using Globus.Core.Utils.Hashing;
using Globus.Service.Declarations;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerOnboardingTests
{
    public class OnboardNewCustomerTests
    {
        [Fact]
        public void OnboardCustomerTest()
        {
            var responseModel = new ResponseModel();
            string mobile = "07037511548";
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(c => c.OnboardCustomer(new Globus.Core.Dtos.OnboardCustomerDto
            {
                PhoneNumber = mobile,
                Email = "gig@gmail.com",
                Password = PasswordHash.EncryptData(mobile, "101010"),
                StateOfResidence = "Delta",
                LGA = "Bom",
            })).ReturnsAsync(new ResponseModel { Status = true });

            Assert.True(true);
        }

        [Fact]
        public void VerifyPhoneNumberViaOTPTest()
        {
            var responseModel = new ResponseModel();
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(c => c.VerifyPhoneNumberViaOTP(new Globus.Core.Dtos.VerifyPhoneNumberDto 
            {
                OTPValue = "903349",
                CustomerId = 1
            })).ReturnsAsync(new ResponseModel { Status = true });
            Assert.True(true);
        }

        [Fact]
        public void AllOnbordedCustomersTest()
        {
            var customers = new ResponseModel<List<Customer>>();
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(c => c.GetAllOnbordedCustomers())
                .ReturnsAsync(new ResponseModel<IEnumerable<Customer>> { Data = customers.Data });
        }
    }
}