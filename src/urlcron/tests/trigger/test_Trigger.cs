using System;
using System.Threading;
using NUnit.Framework;
using urlcron.service.portals;

namespace tests.trigger
{
    [TestFixture]
    public class test_Trigger
    {
        [Test, Explicit]
        public void Acceptance() {
            var are = new AutoResetEvent(false);
            var count = 0;
            
            using (new Trigger(Count_triggerings, 1)) {
                Assert.IsTrue(are.WaitOne(20 * 1000));
                Assert.AreEqual(3, count);
            }

            void Count_triggerings() {
                Console.WriteLine("triggered");
                count++;
                if (count == 3) are.Set();
            }
        }
    }
}