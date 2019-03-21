using System;
using System.Linq;
using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Http;

namespace AcademyDocker.Api.Headers
{
    public class GlobalUserIdServiceHeader : IServiceHeader
    {
        public string Key => ServiceHeaders.GLOBAL_USER_ID;

        public Error Validate(IHeaderDictionary headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (headers.ContainsKey(Key))
            {
                var value = headers[Key].First();
                if (string.IsNullOrEmpty(value))
                {
                    return new Error { Message = $"{Key} is empty.", Code = "Header.GlobalUserId" };
                }

                if (!long.TryParse(value, out _))
                {
                    return new Error { Message = $"{Key} is not from type long.", Code = "Header.GlobalUserId" };
                }
            }

            return null;
        }
    }
}
