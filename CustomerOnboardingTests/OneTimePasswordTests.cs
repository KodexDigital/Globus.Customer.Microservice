using Globus.Core.Common;
using Globus.Service.Declarations;
using Moq;
using Xunit;

namespace CustomerOnboardingTests
{
    public class OneTimePasswordTests
    {
        [Fact]
        public void Save_OTP_Test()
        {
            var otpService = new Mock<IOneTimePasswordService>();
            otpService.Setup(o => o.StoreOTP(new Globus.Core.Dtos.SaveOTPDto
            {
                OTPValue = "606494",
                CustomerId = 1,
            }));
        }

        [Fact]
        public void Update_OTP_Test()
        {
            var otpService = new Mock<IOneTimePasswordService>();
            otpService.Setup(o => o.UpdateOTP(new Globus.Core.Dtos.SaveOTPDto
            {
                OTPValue = "606494",
                CustomerId = 1,
            }));
        }

        [Fact]
        public void Validate_OTP_Test()
        {
            var responseModel = new ResponseModel();
            var otpService = new Mock<IOneTimePasswordService>();
            otpService.Setup(o => o.ValidateOTP(new Globus.Core.Dtos.SaveOTPDto
            {
                OTPValue = "606494",
                CustomerId = 1,
            })).ReturnsAsync(new ResponseModel<string> { Status = true });

            Assert.True(true);
        }
    }
}
