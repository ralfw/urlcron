using System;
using System.Linq;
using NUnit.Framework;
using urlcron.service;
using urlcron.service.providers;

namespace tests.scheduler
{
    [TestFixture]
    public class test_Scheduler
    {
        [Test]
        public void Acceptance()
        {
            var jobs = new[] {
                new JobDto{Id = "a", CreatedAt = new DateTime(2017,8,31,10,0,0), Interval = new TimeSpan(0,1,0)},
                new JobDto{Id = "b", CreatedAt = new DateTime(2017,8,31,10,0,0), Interval = new TimeSpan(0,5,0)},
                new JobDto{Id = "c", CreatedAt = new DateTime(2017,8,31,10,0,0), Interval = new TimeSpan(1,3,0)}
            };

            var result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 0, 0));
            Assert.AreEqual(3, result.Count());

            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 1, 0));
            Assert.AreEqual(new[]{"a"}, result.Select(j => j.Id).ToArray());
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 3, 0));
            Assert.AreEqual(new[]{"a"}, result.Select(j => j.Id).ToArray());
            
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 5, 0));
            Assert.AreEqual(new[]{"a", "b"}, result.Select(j => j.Id).ToArray());
            
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 34, 0));
            Assert.AreEqual(new[]{"a"}, result.Select(j => j.Id).ToArray());
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 10, 35, 0));
            Assert.AreEqual(new[]{"a", "b"}, result.Select(j => j.Id).ToArray());
            
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 11, 3, 0));
            Assert.AreEqual(new[]{"a", "c"}, result.Select(j => j.Id).ToArray());
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 12, 6, 0));
            Assert.AreEqual(new[]{"a", "c"}, result.Select(j => j.Id).ToArray());
            result = Scheduler.Collect_due_jobs(jobs, new DateTime(2017, 8, 31, 15, 15, 0));
            Assert.AreEqual(new[]{"a", "b", "c"}, result.Select(j => j.Id).ToArray());
        }
    }
}