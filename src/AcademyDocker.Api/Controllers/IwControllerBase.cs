using AcademyDocker.Api.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademyDocker.Api.Controllers
{
    [ApiController]
    public abstract class IwControllerBase : ControllerBase
    {
        protected async Task<ServiceHeaders> GetServiceHeaders()
        {
            var serviceHeaders = new ServiceHeaders();
            await TryUpdateModelAsync(serviceHeaders, typeof(ServiceHeaders), string.Empty);
            return serviceHeaders;
        }
    }
}
