using System;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

namespace urlcron.service.portals
{
    public class Trigger : IDisposable {
        private const int DEFAULT_INITIAL_DELAY_MSEC = 10 * 1000;
        private const int DEFAULT_INTERVAL_LENGTH_MSEC = 60 * 1000;
        
        private Timer _timer;

        
        public Trigger(Uri endpoint) {
            Start(() => Trigger_runAllDue(endpoint), DEFAULT_INTERVAL_LENGTH_MSEC);
        }
        
        internal Trigger(Action triggerAction, int intervalLengthMsec) {
            Start(triggerAction, intervalLengthMsec);
        }
        
        
        private void Start(Action triggerAction, int intervalLengthMsec) {
            _timer?.Dispose();
            _timer = new Timer(_ => triggerAction(), null, DEFAULT_INITIAL_DELAY_MSEC, intervalLengthMsec);
        }
        
        public void Stop() => _timer?.Dispose();

        public void Dispose() => Stop();

        
        private void Trigger_runAllDue(Uri endpoint) {
            Console.WriteLine("Triggering at {0}", DateTime.Now);

            try {
                var wc = new WebClient();
                    
                var result = wc.UploadString(endpoint.ToString() + "/runAllDue", "POST");

                var json = new JavaScriptSerializer();
                var status = json.Deserialize<ServicePortal.StatusDto>(result);
                if (status.Code == ServicePortal.StatusDto.StatusCodes.Success)
                    Console.WriteLine("  Successfully triggered");
                else
                    Console.WriteLine("  Failure during trigger processing! Reason: {0}", status.FailureExplanation);
            }
            catch (Exception ex) {
                Console.WriteLine("  Failed triggering due to {0}", ex);
            }
        } 
    }
}