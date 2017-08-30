using System;
using NUnit.Framework;
using urlcron.service;

namespace tests.jobrepository
{
    [TestFixture]
    public class test_JobRepository
    {
        [Test]
        public void Load_job_by_id()
        {
            var sut = new JobRepository(new Uri(""));
        }
    }
}