using Globus.Core.Common;
using Globus.Core.Dtos;

namespace Globus.Service.Declarations
{
    public interface IOneTimePasswordService
    {
        Task StoreOTP(SaveOTPDto dto);
        Task UpdateOTP(SaveOTPDto dto);
        Task<ResponseModel<string>> ValidateOTP(SaveOTPDto dto);
    }
}
