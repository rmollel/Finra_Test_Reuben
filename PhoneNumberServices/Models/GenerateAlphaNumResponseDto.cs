using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberServices.Models
{
    public class GenerateAlphaNumResponseDto
    {
        public List<PhoneNumberDto> AlphaNumbers { get; set; }
        public string OriginalPhoneNumber { get; set; }
        public int TotalNumberOfCombinations { get { return AlphaNumbers.Count(); } }
    }
}
