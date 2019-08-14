using Moq;
using PhoneNumberServices;

namespace PhoneNumberServicesTest
{
    public class MockPhoneNumberUtility : Mock<IPhoneNumberUtility>
    {
       
        public void MockIsValidPhoneNumber(string phoneNumber, string countryCode, bool outPut)
        {
            Setup(
                x => x.IsValidPhoneNumber(It.Is<string>(i => i == phoneNumber), It.Is<string>(i => i == countryCode))
                ).Returns(outPut).Verifiable();
        }


        public void MockIsValidPhoneNumberVerify(string phoneNumber, string countryCode, bool outPut, int callCount)
        {
            

            Verify(x => x.IsValidPhoneNumber(
                It.Is<string>(i => i == phoneNumber), It.Is<string>(i => i == countryCode)
                ).CompareTo(outPut), Times.Exactly(callCount));

        }


        public void MockGetPhoneNumberDigitsOnly(string phoneNumber, string countryCode, char [] outPut)
        {
            Setup(
                x => x.GetPhoneNumberDigitsOnly(It.Is<string>(i => i == phoneNumber), It.Is<string>(i => i == countryCode))
                ).Returns(outPut).Verifiable();
        }


        public void MockGetPhoneNumberDigitsOnlyVerify(string phoneNumber, string countryCode, bool outPut, int callCount)
        {


            Verify(x => x.GetPhoneNumberDigitsOnly(
                It.Is<string>(i => i == phoneNumber), It.Is<string>(i => i == countryCode)
                ).Equals(outPut), Times.Exactly(callCount));

        }


    }
}
