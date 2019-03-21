using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Http;

namespace AcademyDocker.Api.Headers
{
    public interface IServiceHeader
    {
        string Key { get; }

        /// <summary>
        /// Should return null, if the validation is successful
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        Error Validate(IHeaderDictionary headers);
    }
}