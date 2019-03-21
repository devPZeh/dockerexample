using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademyDocker.DataContract.Interfaces.Business
{
    public interface IAuthenticationService
    {
        Task<string> GetOAuthToken();
    }
}