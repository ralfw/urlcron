using System;
using System.Collections.Generic;
using urlcron.service.providers;

namespace urlcron.service
{
    internal static class Scheduler
    {
        public static IEnumerable<JobDto> Collect_due_jobs(IEnumerable<JobDto> jobs, DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}