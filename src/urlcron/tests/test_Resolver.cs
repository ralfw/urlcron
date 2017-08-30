using System;
using dependencylocator;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class test_Resolver
    {
        [Test]
        public void Acceptance()
        {
            Resolver.Clear();
            Resolver.Add<int>(() => 1);
            Resolver.Add<Uri>(() => new Uri("http://localhost:8080"));

            var i = Resolver.Get<int>();
            var uri = Resolver.Get<Uri>();
            Assert.AreEqual("http://localhost:8080/", uri.AbsoluteUri);
        }
    }
}