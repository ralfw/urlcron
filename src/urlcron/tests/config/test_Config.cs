using System;
using NUnit.Framework;
using urlcron.service;

namespace tests.config
{
    [TestFixture]
    public class test_Config
    {
        [SetUp]
        public void Setup() {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }
        
        
        [Test]
        public void Acceptance() {
            var sut = new Config("config/test_Config.config");
            Assert.AreEqual("http://someserver.com/jobsource.txt", sut.JobSource.ToString());
        }
    }
}