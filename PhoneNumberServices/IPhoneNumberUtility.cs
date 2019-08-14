using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberServices
{
    public interface IPhoneNumberUtility
    {
        bool IsValidPhoneNumber(string phoneNumber, string countryCode);
        char [] GetPhoneNumberDigitsOnly(string phoneNumber, string contryCode);
    }
}
