using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaNumericWebApp.Models
{
    public class AppError
    {
        public Guid ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
