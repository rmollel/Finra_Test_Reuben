using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaNumericWebApp.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public List<AppError> Errors { get; set; }
    }


    public class Result<T> : Result
    {
        public T Data;
    }
}
