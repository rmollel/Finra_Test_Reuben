using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberServices
{
    public static class AlphaNumericGeneratorHelper
    {
        static readonly Dictionary<char, char[]> phoneDialKeyPad = new Dictionary<char, char[]>
        {
            { '1',  new char[] { '1' } },
            { '2', new char[] { '2','A', 'B', 'C' } },
            { '3', new char[] { '3', 'D', 'E', 'F' } },
            { '4', new char[] { '4', 'G', 'H', 'I' } },
            { '5', new char[] { '5', 'J', 'K', 'L' } },
            { '6', new char[] { '6', 'M', 'N', 'O' } },
            { '7', new char[] { '7', 'P', 'Q', 'R', 'S' } },
            { '8', new char[] { '8', 'T', 'U', 'V' } },
            { '9', new char[] { '9', 'W', 'X', 'Y', 'Z' } },
            { '0', new char[] { '0' } }
        };

        public static List<string> GenerateAlphaNumCombinations(char[] originalPhoneNumber)
        {
            
            List<string> results = new List<string>();

            if (originalPhoneNumber.Length == 10)
            {
                char[] equivalentAlphaNumber = new char[originalPhoneNumber.Length];
                int startPositon = originalPhoneNumber.Length - 1;

                GetAphaNumbers(originalPhoneNumber, startPositon, phoneDialKeyPad, results, equivalentAlphaNumber);
            }
            else
                throw new ArgumentException("Valid phone number should have 10 digits.");






            return results;
        }


        private static void GetAphaNumbers(char[] originalPhoneNumber, int currPosition, Dictionary<char, char[]> phoneKeyPad, List<string> results, char[] modifiedPhoneNumber)
        {


            for (int i = currPosition; i >= 0; i--)
            {


                var currDigit = originalPhoneNumber[i];
                var currDigitAlphNumChoices = phoneKeyPad[currDigit];

                for (int n = 0; n < currDigitAlphNumChoices.Length; n++)
                {
                    var alphaNumChoice = currDigitAlphNumChoices[n];
                    modifiedPhoneNumber[i] = alphaNumChoice;

                    if (i > 0)
                        GetAphaNumbers(originalPhoneNumber, i - 1, phoneKeyPad, results, modifiedPhoneNumber);
                    else
                    {
                        var modifiedPhoneNumberString = AddSpacesToPhoneNumber(new string(modifiedPhoneNumber));
                        results.Add(modifiedPhoneNumberString);
                    }
                        

                    if (n + 1 == currDigitAlphNumChoices.Length)
                        return;

                }
            }

        }

        private static string AddSpacesToPhoneNumber(string phonenumber)
        {
            string results = string.Empty;
            if (phonenumber.Length == 10)
            {
                var str = new StringBuilder(phonenumber);
                str.Insert(3, " ");
                str.Insert(7, " ");

                results = str.ToString();

            }
            else
                throw new ArgumentException("Valid phone number should have 10 digits.");

            return results;

        }



    }
}
