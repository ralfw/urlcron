using System;
using System.Reflection;
using servicehost.contract;

namespace urlcron.service
{
    [Service]
    public class ServicePortal
    {
        [EntryPoint(HttpMethods.Get, "/info")]
        public string Info() {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}