using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberServices.Models
{
    public class AppError
    {
        public Guid ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
