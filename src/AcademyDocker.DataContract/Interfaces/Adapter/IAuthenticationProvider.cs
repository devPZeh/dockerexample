using System.Threading.Tasks;
using AcademyDocker.DataContract.Data.OAuth;
using AcademyDocker.DataContract.Data.Permissions;

namespace AcademyDocker.DataContract.Interfaces.Adapter
{
    public interface IAuthenticationProvider
    {
        Task<string> GetOAuthToken(string url, string base64AuthString);
    }
}