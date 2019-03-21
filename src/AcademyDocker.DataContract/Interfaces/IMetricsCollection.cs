using System;

namespace AcademyDocker.DataContract.Interfaces
{
    public interface IMetricsCollection
    {
        long TotalRequests { get; }
        TimeSpan MinResponseTime { get; }
        TimeSpan MaxResponseTime { get; }
        TimeSpan AverageResponseTime { get; }

        void AddRequest(long elapsedMilliseconds);
    }
}
