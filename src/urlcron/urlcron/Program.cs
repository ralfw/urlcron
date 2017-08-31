using System;
using System.Collections.Generic;
using dependencylocator;
using Nancy;
using urlcron.service;
using urlcron.service.providers;

namespace urlcron
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new Config();
            Resolver.Add<RequestHandler>(() => new RequestHandler(config));
            
            var endpoint = new Uri(args[0]);
            Server.Run(endpoint);
        }
    }
}