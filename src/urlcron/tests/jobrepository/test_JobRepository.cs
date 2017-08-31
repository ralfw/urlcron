using System;
using NUnit.Framework;
using urlcron.service;
using urlcron.service.providers;

namespace tests.jobrepository
{
    [TestFixture]
    public class test_JobRepository
    {
        [Test]
        public void Load()
        {
            var sut = new Repository(new Uri("http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/jobrepository/test_JobRepository_acceptance.txt"));
            var result = sut.Load();
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("a", result[0].Id);
            Assert.AreEqual(new TimeSpan(1,2,3), result[1].Interval);
            Assert.AreEqual("http://ccd-school.de/b", result[2].Url);
        }
        
        
        [Test]
        public void Load_job_by_id()
        {
            var sut = new Repository(new Uri("http://raw.githubusercontent.com/ralfw/urlcron/master/src/urlcron/tests/jobrepository/test_JobRepository_acceptance.txt"));
            var result = sut.Load("b");
            Assert.AreEqual("b", result.Id);
            Assert.AreEqual(new TimeSpan(1,2,3,4), result.Interval);
            Assert.AreEqual("http://ccd-school.de/b", result.Url);
        }
    }
}