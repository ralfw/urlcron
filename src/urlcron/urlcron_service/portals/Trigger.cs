using System;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

namespace urlcron.service.portals
{
    public class Trigger : IDisposable {
        private const int DEFAULT_INITIAL_DELAY_MSEC = 10 * 1000;
        private const int DEFAULT_INTERVAL_LENGTH_MSEC = 60 * 1000;

        private readonly Action _triggerAction;
        private readonly int _intervalLengthMsec;
        private Timer _timer;

        
        public Trigger(Uri endpoint) {
            _triggerAction = () => Trigger_runAllDue(endpoint);
            _intervalLengthMsec = DEFAULT_INTERVAL_LENGTH_MSEC;
            Start();
        }
        
        internal Trigger(Action triggerAction, int intervalLengthMsec) {
            _triggerAction = triggerAction;
            _intervalLengthMsec = intervalLengthMsec;
            Start();
        }
        
        
        public void Start() {
            Stop();
            
            _timer = new Timer(_ => _triggerAction(), null, DEFAULT_INITIAL_DELAY_MSEC, _intervalLengthMsec);
            Console.WriteLine("Interval trigger started");
        }
        
        public void Stop() {
            _timer?.Dispose();
            _timer = null;
            Console.WriteLine("Interval trigger stopped");
        }

        
        public void Dispose() => Stop();

        
        private static void Trigger_runAllDue(Uri endpoint) {
            Console.WriteLine("{0}: Triggering", DateTime.Now);
            try {
                var wc = new WebClient();
                    
                var result = wc.UploadString(endpoint.ToString() + "/runAllDue", "POST");

                var json = new JavaScriptSerializer();
                var status = json.Deserialize<ServicePortal.StatusDto>(result);
                if (status.Code == ServicePortal.StatusDto.StatusCodes.Failure)
                    Console.WriteLine("  Failure during trigger processing! Reason: {0}", status.FailureExplanation);
            }
            catch (Exception ex) {
                Console.WriteLine("  Failed triggering due to {0}", ex);
            }
        } 
    }
}