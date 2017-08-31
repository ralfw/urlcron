using System;
using dependencylocator;
using urlcron.service;
using urlcron.service.portals;
using urlcron.service.providers;

namespace urlcron
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var endpoint = new Uri(args[0]);
            
            var config = new Config();
            Resolver.Add<RequestHandler>(() => new RequestHandler(config));
            var trigger = new Trigger(endpoint);
            Resolver.Add<Trigger>(() => trigger);
            
            using (trigger) {
                Server.Run(endpoint);
            }
        }
    }
}