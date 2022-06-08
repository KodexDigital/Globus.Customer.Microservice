using Globus.Core.Common;
using Globus.Core.Dtos;
using Globus.Core.Entities;
using Globus.Core.Utils.Helpers;
using Globus.DAL.Repositories.Declarations;
using Globus.Service.Declarations;

namespace Globus.Service.Implementations
{
    public class OneTimePasswordService : IOneTimePasswordService
    {
        private readonly IOneTimePasswordRepository repo;
        private readonly IUnitOfWork uow;

        public OneTimePasswordService(IOneTimePasswordRepository repo, IUnitOfWork uow)
        {
            this.repo = repo;
            this.uow = uow;
        }

        public async Task StoreOTP(SaveOTPDto dto)
        {
            repo.Add(new OneTimePassword
            {
                CustomerId = dto.CustomerId,
                Value = OTPHelper.GenerateSimpleOTP(),  
            });

            await uow.ExecuteCommandAsync();
        }
        public async Task UpdateOTP(SaveOTPDto dto)
        {
            var otp = await uow.OneTimePasswordRepository.GetAsync(o => o.CustomerId.Equals(dto.CustomerId)
                                                          && o.Value.Equals(dto.OTPValue));
            if(otp != null)
            {
                otp.IsUsed = true;
                otp.ValidityTimeSpan = DateTime.Now;
                await uow.ExecuteCommandAsync();
            }
        }

        public async Task<ResponseModel<string>> ValidateOTP(SaveOTPDto dto)
        {
            var result = new ResponseModel<string>();
            var otp = await uow.OneTimePasswordRepository.GetAsync(o => o.Value.Equals(dto.OTPValue) 
                                                                && o.CustomerId.Equals(dto.CustomerId));
            if (otp != null)
            {
                if (otp.IsUsed)
                {
                    result.Status = false;
                    result.Message = "OTP is already been used";
                }
                else
                {
                    //check expiration
                    TimeSpan ts = otp.ValidityTimeSpan - DateTime.Now;
                    var totalMinutes = ts.TotalMinutes;

                    if (totalMinutes > 5)
                    {
                        result.Status = false;
                        result.Message = "OTP has expired";
                    }
                    else
                    {
                        result.Status = true;
                        result.Data = otp.Value;
                        result.Message = "OTP still valid";
                    }
                }
            }

            return result;
        }
    }
}
