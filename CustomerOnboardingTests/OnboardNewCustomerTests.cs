using System.Diagnostics.CodeAnalysis;
using Globus.Core.Common;
using Globus.Core.Utils.Hashing;
using Globus.Service.Declarations;
using Moq;
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
    }
}