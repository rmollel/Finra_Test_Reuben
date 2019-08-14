using PhoneNumbers;
using PhoneNumberServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneNumberServices
{
    public class AlphaNumericGenerator : IAlphaNumericGenerator
    {
        private  readonly IPhoneNumberUtility _phoneNumberUtility;
        public AlphaNumericGenerator(IPhoneNumberUtility phoneNumberUtility)
        {
            _phoneNumberUtility = phoneNumberUtility ?? throw new ArgumentNullException("phoneNumberUtility in class AlphaNumericGenerator is not instantiated.");
        }
        public Result<GenerateAlphaNumResponseDto> GenerateAlphaNumCombinations(string phonedigits, string countryCode)
        {
            Result<GenerateAlphaNumResponseDto> results = new Result<GenerateAlphaNumResponseDto>();

            try
            {
                if (!_phoneNumberUtility.IsValidPhoneNumber(phonedigits, countryCode))
                {
                    
                    results.Errors = new List<AppError> {
                        new AppError { ErrorCode = new Guid("2BE9A732-F778-4D0F-ACA0-9834929F5C66"),
                            ErrorMessage = "Incorrect phone number has been specified" }

                    };
                    results.Success = false;
                    return results;
                }


                var phoneDigitsOnly = _phoneNumberUtility.GetPhoneNumberDigitsOnly(phonedigits, countryCode);
                var listOfNumbers = AlphaNumericGeneratorHelper.GenerateAlphaNumCombinations(phoneDigitsOnly).Select(phoneNum => new PhoneNumberDto { Phone = phoneNum }).ToList();

                
                results.Data = new GenerateAlphaNumResponseDto { AlphaNumbers = listOfNumbers, OriginalPhoneNumber = phonedigits };
                results.Success = true;

                
            }
            catch(Exception ex)
            {
                AppError err = new AppError {
                    ErrorCode = new Guid("2BE9A732-F778-4D0F-ACA0-9834929F5C66"),
                    ErrorMessage = ex.Message
                };

                results.Errors = new List<AppError> { err };
                results.Success = false;
                return results;
            }

            return results;
        }
    }
}
