using System;
using servicehost.contract;

namespace urlcron.service.portals
{
    [Service]
    public class DemoPortal
    {
        [EntryPoint(HttpMethods.Get, "/demo")]
        public void Demo(string text) {
            Console.WriteLine("Demo endpoint called with '{0}'", text);
        }
    }
}