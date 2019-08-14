using PhoneNumberServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberServices
{
    public interface IAlphaNumericGenerator
    {
        Result<GenerateAlphaNumResponseDto>  GenerateAlphaNumCombinations(string phonedigits, string countryCode);
    }
}
