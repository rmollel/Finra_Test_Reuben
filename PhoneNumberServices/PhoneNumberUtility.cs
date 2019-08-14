using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberServices
{
    public class PhoneNumberUtility : IPhoneNumberUtility
    {
        private  readonly PhoneNumberUtil _phoneNumberUtil = null;

        public PhoneNumberUtility(PhoneNumberUtil phoneNumberUtil)
        {
            _phoneNumberUtil = phoneNumberUtil ?? throw new ArgumentNullException("phoneNumberUtil in class PhoneNumberUtility is not instantiated.");
        }

        public bool IsValidPhoneNumber(string phoneNumber, string countryCode)
        {
            var phoneNumberObject = _phoneNumberUtil.Parse(phoneNumber, countryCode);
            return _phoneNumberUtil.IsValidNumber(phoneNumberObject);
        }
        public char[] GetPhoneNumberDigitsOnly(string phoneNumber, string contryCode)
        {
            
            var phoneNumberObject = _phoneNumberUtil.Parse(phoneNumber, contryCode);
            return phoneNumberObject.NationalNumber.ToString().ToCharArray();
        }

        
    }
}
