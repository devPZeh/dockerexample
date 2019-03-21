using System.Threading.Tasks;
using AcademyDocker.DataContract.Data.Permissions;

namespace AcademyDocker.DataContract.Interfaces.Adapter
{
    public interface IPermissionProvider
    {
        Task<Permission[]> GetPermissions(string url, string context, string oAuthToken);
    }
}