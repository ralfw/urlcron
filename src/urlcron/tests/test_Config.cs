using System;
using NUnit.Framework;
using urlcron.service;

namespace tests
{
    [TestFixture]
    public class test_Config
    {
        [SetUp]
        public void Setup() {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }
        
        
        [Test]
        public void Acceptance()
        {
            var sut = new Config("test_Config.config");
            Assert.AreEqual("/test source", sut.JobSource);
        }
    }
}