using System;
using System.Runtime.InteropServices.ComTypes;

namespace urlcron.service
{
    public class RequestHandler
    {
        private readonly Config _config;

        public RequestHandler(Config config) {
            _config = config;
        }
        
        
        public void Run(string jobId)
        {
            /*
            * Job-Quelle bestimmen
            * Jobs laden
            * Job finden
            * Job ausführen
            */

            var sourceUri = _config.JobSource;

            var jobRepo = new JobRepository(sourceUri);
            jobRepo.Load(jobId);
        }
    }
}