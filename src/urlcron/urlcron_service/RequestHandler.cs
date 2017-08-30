using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

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
            var sourceUri = _config.JobSource;
            
            var repo = new Repository(sourceUri);
            var job = repo.Load(jobId);

            Runner.Run(job);
        }
    }
}