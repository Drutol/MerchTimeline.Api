using System;
using System.Collections.Generic;
using System.Text;

namespace MerchTimeline.Domain.Exceptions
{
    public class RequestException : Exception
    {
        public RequestException(string message) : base(message)
        {

        }
    }
}
