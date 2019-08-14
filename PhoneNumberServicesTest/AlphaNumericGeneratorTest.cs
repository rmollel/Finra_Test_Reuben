using PhoneNumberServices;
using PhoneNumberServices.Models;
using System;
using Xunit;
using System.Linq;

namespace PhoneNumberServicesTest
{
    public class AlphaNumericGeneratorTest
    {
        [Fact]
        public void ValidPhoneNumber_ShouldReturn_ListofAlphaNumbersAndNoErrors()
        {
            //ARRANGE
            var testPhoneNumber = "202 256 6987";
            var testPhoneNumberChar = new char[] { '2','0', '2', '2', '5', '6', '6', '9', '8', '7' };


            var IPhoneNumberUtilityMock = new MockPhoneNumberUtility();
            IPhoneNumberUtilityMock.MockIsValidPhoneNumber(testPhoneNumber, "US", true);
            IPhoneNumberUtilityMock.MockGetPhoneNumberDigitsOnly(testPhoneNumber, "US", testPhoneNumberChar);

            var _alphaNumericGenerator = new AlphaNumericGenerator(IPhoneNumberUtilityMock.Object);

            var listOfNumbers = AlphaNumericGeneratorHelper.GenerateAlphaNumCombinations(testPhoneNumberChar).Select(phoneNum => new PhoneNumberDto { Phone = phoneNum }).ToList();
            var expectedResults = new Result<GenerateAlphaNumResponseDto>();
            expectedResults.Data = new GenerateAlphaNumResponseDto { AlphaNumbers = listOfNumbers, OriginalPhoneNumber = testPhoneNumber };
            expectedResults.Success = true;
            
            //ACT
            var actualResults = _alphaNumericGenerator.GenerateAlphaNumCombinations(testPhoneNumber, "US");

            //ASSERT
            Assert.NotNull(actualResults);
            Assert.Equal(expectedResults.Data.AlphaNumbers.Count(), actualResults.Data.AlphaNumbers.Count());
            Assert.Equal(expectedResults.Success, actualResults.Success);
            Assert.Null(actualResults.Errors);

            

        }

        [Fact]
        public void InValidPhoneNumber_ShouldReturn_ResultObjectWithErrorsAndEmptyPhoneNumListAndSuccessFlagFalse()
        {
            //ARRANGE
            var testPhoneNumber = "202 256 6987987";
            var testPhoneNumberChar = new char[] { '2', '0', '2', '2', '5', '6', '6', '9', '8', '7', '9', '8', '7' };


            var IPhoneNumberUtilityMock = new MockPhoneNumberUtility();
            IPhoneNumberUtilityMock.MockIsValidPhoneNumber(testPhoneNumber, "US", true);
            IPhoneNumberUtilityMock.MockGetPhoneNumberDigitsOnly(testPhoneNumber, "US", testPhoneNumberChar);

            var _alphaNumericGenerator = new AlphaNumericGenerator(IPhoneNumberUtilityMock.Object);

            
            var expectedResults = new Result<GenerateAlphaNumResponseDto>();
            expectedResults.Data = null;
            expectedResults.Success = false;

            //ACT
            var actualResults = _alphaNumericGenerator.GenerateAlphaNumCombinations(testPhoneNumber, "US");

            //ASSERT
            Assert.NotNull(actualResults);
            Assert.Null(expectedResults.Data);
            Assert.Equal(expectedResults.Success, actualResults.Success);
            Assert.NotNull(actualResults.Errors);



        }
    }
}
