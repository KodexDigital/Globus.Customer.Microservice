using Globus.Core.Common;
using Globus.Core.Dtos;
using Globus.Core.Entities;
using Globus.Core.Enums;
using Globus.Core.Utils.Hashing;
using Globus.DAL.Repositories.Declarations;
using Globus.Service.Declarations;

namespace Globus.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repo;
        private readonly IUnitOfWork uow;
        private readonly IOneTimePasswordService otpService;

        public CustomerService(ICustomerRepository repo, IUnitOfWork uow, IOneTimePasswordService otpService)
        {
            this.repo = repo;
            this.uow = uow;
            this.otpService = otpService;
        }

        public async Task<ResponseModel> OnboardCusoter(OnboardCustomerDto dto)
        {
            var response = new ResponseModel();
            var custExists = await uow.CustomerRepository.ExistAsync(c => c.PhoneNumber.ToLower().Equals(dto.PhoneNumber.ToLower()) 
                                                                  || c.Email.ToLower().Equals(dto.Email.ToLower()));
            if (custExists)
            {
                response.Status = false;
                response.Message = "Customer already exists";
            }

            //validate state and lga mapping

            repo.Add(new Customer 
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Password = PasswordHash.EncryptData(dto.PhoneNumber, dto.Password),
                StateOfResidence = dto.StateOfResidence,
                LGA = dto.LGA,
                OnboardingStatus = OnboardingStatus.NotSpecified
            });

            var result = await uow.ExecuteCommandAsync();

            if (result > 0)
            {
                response.Status = true;
                response.Message = $"Customer added and OTP sent to phone number for verification";


                //get current customer
                var data = await uow.CustomerRepository.GetAsync(d => d.Email.ToLower().Equals(dto.Email.ToLower()));
                //general otp
                await otpService.StoreOTP(new SaveOTPDto { CustomerId = data.CustomerId });
            }
            else
            {
                response.Status = false;
                response.Message = "Onboarding was not successful";
            }

            return response;
        }
        public async Task<ResponseModel> VerifyPhoneNumberViaOTP(VerifyPhoneNumberDto dto)
        {
            var response = new ResponseModel();
            var cust = await uow.CustomerRepository.GetAsync(d => d.CustomerId.Equals(dto.CustomerId));
            if (cust != null)
            {
                var validate = await otpService.ValidateOTP(new SaveOTPDto 
                { 
                    OTPValue = dto.OTPValue,
                    CustomerId = dto.CustomerId
                });

                if (validate.Status.Equals(true))
                {
                    cust.IsOnboarded = true;
                    cust.OnboardingStatus = OnboardingStatus.Completed;
                    await uow.ExecuteCommandAsync();

                    await otpService.UpdateOTP(new SaveOTPDto
                    {
                        OTPValue = dto.OTPValue,
                        CustomerId = dto.CustomerId
                    });

                    response.Status = true;
                    response.Message = "Phone verified successfully";
                }
                else
                {
                    response.Status = false;
                    response.Message = "verification failed";
                }
            }

            return response;
        }
        public async Task<ResponseModel<IEnumerable<Customer>>> GetAllOnbordedCustomers()
        {
            var list = await uow.CustomerRepository.GetAsync();
            return new ResponseModel<IEnumerable<Customer>>
            {
                Status = list.Count() > 0 ? true : false,
                Data = list.OrderByDescending(l => l.DateCreated),
                Message = list.Count() > 0 ? $"{list.Count()} customer(s) found" : "No record found"
            };
        }
    }
}
