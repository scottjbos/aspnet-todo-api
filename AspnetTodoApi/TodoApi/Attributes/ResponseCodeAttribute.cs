using System;
using System.Collections.Generic;
using System.Net;

namespace TodoApi.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ResponseCodesAttribute : Attribute
    {
        public ResponseCodesAttribute(params HttpStatusCode[] statusCodes)
        {
            ResponseCodes = statusCodes;
        }

        public IEnumerable<HttpStatusCode> ResponseCodes { get; }
    }
}