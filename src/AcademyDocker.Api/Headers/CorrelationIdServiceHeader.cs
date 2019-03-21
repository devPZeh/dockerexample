using System;
using System.Linq;
using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Http;

namespace AcademyDocker.Api.Headers
{
    public class CorrelationIdServiceHeader : IServiceHeader
    {
        public string Key => ServiceHeaders.CORRELATION_ID;

        public Error Validate(IHeaderDictionary headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (!headers.ContainsKey(Key))
            {
                return null; //This header is not nescessary!
            }

            if (string.IsNullOrEmpty(headers[Key].First()))
            {
                return new Error { Message = $"{Key} is empty.", Code = "Header.CorrelationId" };
            }

            if (!Guid.TryParse(headers[Key].First(), out _))
            {
                return new Error { Message = $"{Key} is not a guid.", Code = "Header.CorrelationId" };
            }

            return null;
        }
    }
}
