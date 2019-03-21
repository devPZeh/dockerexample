using System;
using AcademyDocker.DataContract.Interfaces;

namespace AcademyDocker.Api.Metrics
{
    public class MetricsCollection : IMetricsCollection
    {
        private readonly object addRequestLock = new object();

        public long TotalRequests { get; private set; }
        public TimeSpan MinResponseTime { get; private set; }
        public TimeSpan MaxResponseTime { get; private set; }
        public TimeSpan AverageResponseTime { get; private set; }

        private long SumTotalElapsedMilliseconds { get; set; }

        public MetricsCollection()
        {
            TotalRequests = 0;
            SumTotalElapsedMilliseconds = 0;
            MinResponseTime = TimeSpan.MaxValue;
            MaxResponseTime = TimeSpan.MinValue;
            AverageResponseTime = TimeSpan.Zero;

        }

        public void AddRequest(long elapsedMilliseconds)
        {
            lock (addRequestLock)
            {
                if (elapsedMilliseconds < (long)MinResponseTime.TotalMilliseconds)
                {
                    MinResponseTime = TimeSpan.FromMilliseconds(elapsedMilliseconds);
                }

                if (elapsedMilliseconds > (long)MaxResponseTime.TotalMilliseconds)
                {
                    MaxResponseTime = TimeSpan.FromMilliseconds(elapsedMilliseconds);
                }

                TotalRequests++;
                SumTotalElapsedMilliseconds += elapsedMilliseconds;

                double avg = SumTotalElapsedMilliseconds / (double)TotalRequests;
                AverageResponseTime = TimeSpan.FromMilliseconds(avg);
            }
        }
    }
}
