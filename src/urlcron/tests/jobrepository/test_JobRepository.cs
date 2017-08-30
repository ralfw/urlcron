using System;
using NUnit.Framework;
using urlcron.service;

namespace tests.jobrepository
{
    [TestFixture]
    public class test_JobRepository
    {
        [Test]
        public void Load()
        {
            var sut = new JobRepository(new Uri("http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/jobrepository/test_JobRepository_acceptance.txt"));
            var result = sut.Load();
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("a", result[0].Id);
            Assert.AreEqual("http://ccd-school.de/empty", result[1].Url);
            Assert.AreEqual("b", result[2].Id);
        }
        
        
        [Test]
        public void Load_job_by_id()
        {
            var sut = new JobRepository(new Uri("http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/jobrepository/test_JobRepository_acceptance.txt"));
            var result = sut.Load("b");
            Assert.AreEqual("b", result.Id);
            Assert.AreEqual("http://ccd-school.de/b", result.Url);
        }
    }
}