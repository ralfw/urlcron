using System;
using System.Collections.Generic;
using Nancy;

namespace urlcron
{
    internal class Program
    {
        public static void Main(string[] args) {
            var endpoint = new Uri(args[0]);
            Server.Run(endpoint);
        }
    }
}