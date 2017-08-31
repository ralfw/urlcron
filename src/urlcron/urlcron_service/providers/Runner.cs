using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace urlcron.service.providers
{
    internal class Runner
    {
        public static void Run(IEnumerable<JobDto> jobs) {
            var joblist = jobs.ToList();
            Console.WriteLine($"{DateTime.Now}: Running {joblist.Count} jobs...");
            
            joblist.ForEach(RunAsync);
        }

        public static void RunAsync(JobDto job) {
            RunAsync(job,
                () => Console.WriteLine($"Succeeded running {job.Id} at {job.Url}"),
                errMsg => Console.WriteLine($"FAILED running {job.Id} at {job.Url}! Reason: {errMsg}"));
        }
        
        internal static void RunAsync(JobDto job, Action onSuccess, Action<string> onFailure) {
            ThreadPool.QueueUserWorkItem(_ => {
                try {
                    var wc = new WebClient();
                    wc.DownloadString(job.Url);
                    onSuccess();
                }
                catch (Exception ex) {
                    onFailure(ex.ToString());
                }
            }, null);
        }
    }
}