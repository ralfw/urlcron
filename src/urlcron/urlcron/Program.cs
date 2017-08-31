using System;
using System.Collections.Generic;
using dependencylocator;
using Nancy;
using urlcron.service;

namespace urlcron
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var config = new Config();
            Resolver.Add<Config>(() => config);
            
            var endpoint = new Uri(args[0]);
            Server.Run(endpoint);
        }
    }
}