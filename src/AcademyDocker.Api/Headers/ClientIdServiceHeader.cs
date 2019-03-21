using System;
using System.Linq;
using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Http;

namespace AcademyDocker.Api.Headers
{
    public class ClientIdServiceHeader : IServiceHeader
    {
        public string Key => ServiceHeaders.CLIENT_ID;

        public Error Validate(IHeaderDictionary headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (!headers.ContainsKey(Key))
            {
                return new Error() { Message = $"{Key} is not set. It is required", Code = "Header.ClientId" };
            }

            if (string.IsNullOrEmpty(headers[Key].First()))
            {
                return new Error() { Message = $"{Key} is empty.", Code = "Header.ClientId" };
            }

            return null;
        }
    }
}
