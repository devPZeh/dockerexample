using AcademyDocker.DataContract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyDocker.Api.Controllers
{
    [Route("manage")]
    [Produces("application/json")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ManageController : Controller
    {
        private readonly IMetricsCollection _metricsCollection;

        public ManageController(IMetricsCollection metricsCollection)
        {
            _metricsCollection = metricsCollection;
        }

        [HttpGet]
        [Route("info")]
        public IActionResult Info()
        {
            return Ok(new
            {
                name = "AcademyDocker",
                version = "1.0.0", //TODO: What about the version?
            });
        }

        [HttpGet]
        [Route("metrics")]
        public IActionResult Metrics()
        {
            return Ok(new
            {
                totalRequests = _metricsCollection.TotalRequests,
                minResponseTime = _metricsCollection.MinResponseTime,
                maxResponseTime = _metricsCollection.MaxResponseTime,
                averageResponseTime = _metricsCollection.AverageResponseTime
            });
        }

        [HttpGet]
        [Route("health")]
        public IActionResult Health()
        {
            //Important: This route is used for marathon health checks
            return Ok();
        }
    }
}