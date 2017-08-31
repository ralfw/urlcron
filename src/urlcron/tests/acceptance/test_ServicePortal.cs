using System;
using System.Net;
using dependencylocator;
using NUnit.Framework;
using servicehost;
using servicehost.contract;
using urlcron.service;
using urlcron.service.providers;

namespace tests.acceptance
{
    [TestFixture]
    public class test_ServicePortal
    {
        [Test, Explicit]
        public void Acceptance()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            var config = new Config("acceptance/urlcron_acceptance.config");
            Resolver.Add<RequestHandler>(() => new RequestHandler(config));
            
            using (var sh = new ServiceHost()) {
                sh.Start(new Uri("http://localhost:8080"));
                Console.WriteLine("Started server...");
                
                var wc = new WebClient();
                var result = wc.UploadString("http://localhost:8080/runAllDue", "POST", "");
                Console.WriteLine(result);
            }
        }
    }


    [Service]
    public class TestService
    {
        [EntryPoint(HttpMethods.Get, "/test")]
        public void Test(string jobname) {
            Console.WriteLine("Job '{0}' at {1}", jobname, DateTime.Now);
        }
    }
}