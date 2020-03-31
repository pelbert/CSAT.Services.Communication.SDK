using System;
using System.Collections.Generic;
using System.Text;

namespace CSAT.Services.Communication.SDK
{
    public class ServiceException : Exception
    {
        public ServiceException(Error error, Exception innerException = null)
            : base(null, innerException)
        {
            this.Error = error;
        }

        public Error Error { get; private set; }

        public bool IsMatch(string errorCode)
        {
            if (string.IsNullOrEmpty(errorCode))
            {
                throw new ArgumentException("errorCode cannot be null or empty", "errorCode");
            }

            var currentError = this.Error;

            while (currentError != null)
            {
                if (string.Equals(currentError.Code, errorCode, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                currentError = currentError.InnerError;
            }

            return false;
        }

        public override string ToString()
        {
            if (this.Error != null)
            {
                return this.Error.ToString();
            }

            return null;
        }
    }
}
