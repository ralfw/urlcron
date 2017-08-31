using System;
using System.Diagnostics;
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

            var sut = new Trigger(Count_triggerings, 1*1000); // starts with 10sec delay
            using (sut) {
                Thread.Sleep(12*1000);
                sut.Stop();
                Thread.Sleep(3*1000);
                sut.Start(); // starts with 10sec delay
                are.WaitOne(10*1000);
            }
            Assert.IsTrue(3 <= count && count <= 4);

            void Count_triggerings() {
                Console.WriteLine("triggered");
                count++;
            }
        }
    }
}