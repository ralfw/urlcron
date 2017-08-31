using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace urlcron.service.providers
{
    internal class JobDto {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public TimeSpan Interval { get; set; }
        public string Url { get; set; }
    }
    
    
    internal class Repository
    {
        private readonly Uri _soureUri;
        
        public Repository(Uri soureUri) {
            _soureUri = soureUri;
        }

        
        public JobDto[] Load() {
            var textJobs = Load(_soureUri);
            return Parse(textJobs).ToArray();
        }
        
        public JobDto Load(string jobId) {
            var textJobs = Load(_soureUri);
            var jobs = Parse(textJobs);
            return Find(jobs, jobId);
        }

        
        /*
            Repository CSV text structure:
            
            <job id> ";" <createdAt> ";" <interval as [dd:]hh:mm:ss> ";" <url>
            
            - Each line contains a job description like above. Example:
            
            123;2017-08-31T08:56;1:15:00;http://localhost:8080
            
            - Empty lines and lines starting with "#" are skipped.
        */
        private static IEnumerable<JobDto> Parse(string textJobs)
        {
            var linesJobs = new StringReader(textJobs);
            while (true)
            {
                var lineJob = linesJobs.ReadLine();
                if (lineJob == null) break;

                lineJob = lineJob.Trim();
                if (string.IsNullOrEmpty(lineJob) || lineJob.StartsWith("#")) continue;

                var partsJob = lineJob.Split(';');

                yield return new JobDto {
                    Id = partsJob[0].Trim(),
                    CreatedAt = DateTime.Parse(partsJob[1]),
                    Interval = TimeSpan.Parse(partsJob[2]),
                    Url = partsJob[3].Trim()
                };
            }
        }

        
        private static JobDto Find(IEnumerable<JobDto> jobs, string jobId)
        {
            var job = jobs.FirstOrDefault(j => j.Id == jobId);
            if (job == null) throw new ApplicationException($"No job with id '{jobId}' found!");
            return job;
        }
        
        
        // ReSharper disable once MemberCanBeMadeStatic.Local
        private string Load(Uri source) {
            var wc = new WebClient();
            return wc.DownloadString(source);
        }
    }
}