using System;
using NUnit.Framework;
using urlcron.service;
using urlcron.service.providers;

namespace tests.runner
{
    [TestFixture]
    public class test_Runner
    {
        [Test]
        public void Run() {
            var job = new JobDto { Id= "test", Url = "http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/runner/test_Runner_endpoint.txt"};
            Runner.Run(job);
        }
        
        [Test, Explicit]
        public void Run_with_non_existent_endpoint() {
            var job = new JobDto { Id= "testMissing", Url = "http://does-not-exist.com/missing"};
            Assert.Throws<ApplicationException>(() => Runner.Run(job));
        }
    }
}