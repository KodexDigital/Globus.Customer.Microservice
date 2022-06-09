using Globus.Core.Utils.Hashing;
using Globus.Core.Utils.Helpers;
using Xunit;

namespace CustomerOnboardingTests
{
    public class UtilitiesTests
    {
        [Fact]
        public void OTP_Helper_Generate_Test()
        {
            var otpHelper = OTPHelper.GenerateSimpleOTP();
            Assert.NotNull(otpHelper);
            Assert.NotEmpty(otpHelper);
            Assert.InRange(6, 1, 6);
        }

        [Fact]
        public void Password_Hash_Test()
        {
            var hash = PasswordHash.EncryptData("070", "1111");
            Assert.NotEmpty(hash); 
        }

        [Fact]
        public void Un_Hash_Password_Test()
        {
            var hash = PasswordHash.DecryptData("070", "IwpQnJLP1D7G7ENT8GE8LQ==");
            Assert.NotEmpty(hash);
        }
    }
}
