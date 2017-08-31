using System;
using System.Reflection;
using dependencylocator;
using servicehost.contract;

// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace urlcron.service.portals
{
    [Service]
    public class ServicePortal
    {
        public class StatusDto
        {
            public enum StatusCodes {
                Success,
                Failure
            }
            
            public static StatusDto Success => new StatusDto {Code = StatusCodes.Success, FailureExplanation = ""};
            public static StatusDto Failure(string explanation) => new StatusDto { Code = StatusCodes.Failure, FailureExplanation = explanation};
        
            public StatusCodes Code { get; set; }
            public string FailureExplanation { get; set; }
        }


        private readonly RequestHandler _reqh;
        
        public ServicePortal() {
            _reqh = Resolver.Get<RequestHandler>();
        }
        
        
        [EntryPoint(HttpMethods.Post, "/runAllDue")]
        public StatusDto RunAllDue()
        {
            try {
                _reqh.RunAllDue();
                return StatusDto.Success;
            }
            catch (Exception ex) {
                return StatusDto.Failure($"Failed to run due jobs! Reason: {ex}");
            }
        }
        
        [EntryPoint(HttpMethods.Post, "/run")]
        public StatusDto Run(string jobId)
        {
            try {
                _reqh.Run(jobId);
                return StatusDto.Success;
            }
            catch (Exception ex) {
                return StatusDto.Failure($"Failed to run job with id '{jobId}'! Reason: {ex}");
            }
        }
        

        [EntryPoint(HttpMethods.Get, "/info")]
        public string Info() {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}