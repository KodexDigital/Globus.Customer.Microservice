namespace Globus.Core.Utils.Helpers
{
    public class OTPHelper
    {
        public static string GenerateSimpleOTP()
            => Guid.NewGuid().ToString("N").Substring(0, 6);
    }
}
