using System.Diagnostics;
using System.Threading.Tasks;
using AcademyDocker.DataContract.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AcademyDocker.Api.Middleware
{
    public class MetricCollectorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMetricsCollection _metrics;

        public MetricCollectorMiddleware(RequestDelegate next, IMetricsCollection metrics)
        {
            _next = next;
            _metrics = metrics;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            _metrics.AddRequest(watch.ElapsedMilliseconds);
        }
    }
}