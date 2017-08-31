using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace urlcron.service.providers
{
    internal class Runner
    {
        public static void Run(IEnumerable<JobDto> jobs) {
            var joblist = jobs.ToList();
            Console.WriteLine($"{DateTime.Now}: Running {joblist.Count} jobs:");
            
            joblist.ForEach(Run);
        }
        
        
        public static void Run(JobDto job) {
            Console.Write($"Running '{job.Id}' at '{job.Url}'... ");
            try {
                var wc = new WebClient();
                wc.DownloadString(job.Url);
                Console.WriteLine("Succeeded!");
            }
            catch (Exception ex) {
                Console.WriteLine("FAILED!");
                throw new ApplicationException($"Unable to run job '{job.Id}' at '{job.Url}'! Reason: {ex}");
            }
        }
    }
}