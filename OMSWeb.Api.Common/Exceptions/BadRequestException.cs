using System;
using System.Collections.Generic;
using System.Text;

namespace OMSWeb.Api.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
