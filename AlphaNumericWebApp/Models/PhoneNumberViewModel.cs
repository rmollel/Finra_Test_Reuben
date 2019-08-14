using System.ComponentModel.DataAnnotations;

namespace AlphaNumericWebApp.Models
{
    public class PhoneNumberViewModel
    {
        [Required( AllowEmptyStrings = false, ErrorMessage = "Valid USA phone number required.")]
        public string OriginalPhoneNumber { get; set; }
    }
}
