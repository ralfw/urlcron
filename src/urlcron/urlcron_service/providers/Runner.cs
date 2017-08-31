using System;
using System.Net;

namespace urlcron.service.providers
{
    class Runner
    {
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