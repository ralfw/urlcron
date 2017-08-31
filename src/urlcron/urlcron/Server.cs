using System;
using Mono.Unix;
using Mono.Unix.Native;
using servicehost;

namespace urlcron
{
    internal class Server 
    {
        public static void Run(Uri endpoint) {
            using (var servicehost = new ServiceHost()) {
                servicehost.Start(endpoint);
                Console.WriteLine("Service host running on {0}...", endpoint.ToString());

                if (Is_running_on_Mono) {
                    Console.WriteLine("Ctrl-C to stop service host");
                    UnixSignal.WaitAny(UnixTerminationSignals);
                }
                else {
                    Console.WriteLine("ENTER to stop service host");
                    Console.ReadLine();
                }

                Console.WriteLine("Stopping service host");
                servicehost.Stop();
            }
        } 
        
        private static bool Is_running_on_Mono => Type.GetType("Mono.Runtime") != null;

        private static UnixSignal[] UnixTerminationSignals =>  new[] {
            new UnixSignal(Signum.SIGINT),
            new UnixSignal(Signum.SIGTERM),
            new UnixSignal(Signum.SIGQUIT),
            new UnixSignal(Signum.SIGHUP)
        };
    }
}