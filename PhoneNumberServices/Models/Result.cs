using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberServices.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public List<AppError> Errors { get; set; }

        public string ErrorsToString()
        {
            var errorString = string.Empty;

            if (Errors != null && Errors.Count > 0)
            {
                foreach (var err in Errors)
                {
                    if (!string.IsNullOrEmpty(err.ErrorMessage))
                        errorString = errorString + err.ErrorMessage;
                    
                }
            }

            return errorString.Trim();

        }
    }


    public class Result<T> : Result
    {
        public T Data;
    }
}
