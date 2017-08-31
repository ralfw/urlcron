using System;
using urlcron.service.providers;

namespace urlcron.service
{
    public class RequestHandler
    {
        private readonly Config _config;

        public RequestHandler(Config config) {
            _config = config;
        }
        
        
        public void Run(string jobId) {
            var repo = new Repository(_config.JobSource);
            var job = repo.Load(jobId);

            Runner.Run(job);
        }
        
        
        public void RunAllDue() {
            var repo = new Repository(_config.JobSource);
            var jobs = repo.Load();
            
            var dueJobs = Scheduler.Collect_due_jobs(jobs, DateTime.Now.ToUniversalTime());
            
            Runner.Run(dueJobs);
        }
    }
}