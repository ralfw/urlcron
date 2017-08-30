using NUnit.Framework;
using urlcron.service;

namespace tests.runner
{
    [TestFixture]
    public class test_Runner
    {
        [Test]
        public void Run()
        {
            var job = new JobDto { Id= "test", Url = "http://"};
            Runner.Run(job);
        }
    }
}