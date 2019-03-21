using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademyDocker.DataContract.Interfaces.Business
{
    public interface IPermissionService
    {
        Task<bool> HasPermission(IEnumerable<string> currentRoles, IEnumerable<string> requiredPermissions);
    }
}