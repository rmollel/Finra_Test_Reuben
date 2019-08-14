using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaNumericWebApp.Models
{
    public class AlphaNumbersViewModel
    {
        public List<string> AlphaNumbers { get; set; }
        public string OriginalPhoneNumber { get; set; }
        public int TotalNumberOfCombinations { get { return AlphaNumbers.Count(); } }
    }
}
