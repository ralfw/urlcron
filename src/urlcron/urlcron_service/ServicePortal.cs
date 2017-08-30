using System;
using System.Reflection;
using servicehost.contract;
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace urlcron.service
{
    public enum StatusCodes {
        Success,
        Failure
    }
    
    public class Status
    {
        public static Status Success => new Status {Code = StatusCodes.Success, FailureExplanation = ""};
        public static Status Failure(string explanation) => new Status { Code = StatusCodes.Failure, FailureExplanation = explanation};
        
        public StatusCodes Code { get; set; }
        public string FailureExplanation { get; set; }
    }
    
    
    [Service]
    public class ServicePortal
    {
        [EntryPoint(HttpMethods.Post, "/run")]
        public Status Run(string job)
        {
            return job.IndexOf("999") >= 0
                ? Status.Failure("Oh, no!")
                : Status.Success;
        }
        
        
        [EntryPoint(HttpMethods.Get, "/info")]
        public string Info() {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}