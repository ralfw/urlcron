using System;
using dependencylocator;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class test_DependencyLocator
    {
        [Test]
        public void Acceptance()
        {
            DependencyLocator.Clear();
            DependencyLocator.Add<int>(() => 1);
            DependencyLocator.Add<Uri>(() => new Uri("http://localhost:8080"));

            var i = DependencyLocator.Get<int>();
            var uri = DependencyLocator.Get<Uri>();
            Assert.AreEqual("http://localhost:8080/", uri.AbsoluteUri);
        }
    }
}