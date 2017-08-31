using System;
using System.Threading;
using NUnit.Framework;
using urlcron.service;
using urlcron.service.providers;

namespace tests.runner
{
    [TestFixture]
    public class test_Runner
    {
        [Test]
        public void Run()
        {
            var are = new AutoResetEvent(false);
            var job = new JobDto { Id= "test", Url = "http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/runner/test_Runner_endpoint.txt"};

            Runner.RunAsync(job, 
                () => are.Set(),
                _ => Assert.Fail());
            
            Assert.IsTrue(are.WaitOne(1000));
        }
        
        
        [Test, Explicit]
        public void Run_with_non_existent_endpoint() {
            var are = new AutoResetEvent(false);
            var job = new JobDto { Id= "testMissing", Url = "http://does-not-exist.com/missing"};

            Runner.RunAsync(job, 
                Assert.Fail,
                _ => are.Set());
            
            Assert.IsTrue(are.WaitOne(90000)); // Timeout should be longer than WebClient timeout in RunAsync()
        }
    }
}