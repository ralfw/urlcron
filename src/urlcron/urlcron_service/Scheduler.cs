using System;
using System.Collections.Generic;
using System.Linq;
using urlcron.service.providers;

namespace urlcron.service
{
    internal static class Scheduler
    {
        public static IEnumerable<JobDto> Collect_due_jobs(IEnumerable<JobDto> jobs, DateTime now)
        {
            return jobs.Where(IsDue);

            bool IsDue(JobDto job) {
                var elapsed = now.Subtract(job.CreatedAt);
                Math.DivRem((int)elapsed.TotalMinutes, (int)job.Interval.TotalMinutes, out int rem);
                return rem == 0;
            }
        }
    }
}