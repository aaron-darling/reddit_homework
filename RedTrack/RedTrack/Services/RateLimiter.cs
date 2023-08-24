using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTrack.Services
{
    public class RateLimiter : IRateLimiter
    {
        public int RemainingRequests { get; private set; }
        public int SecondsToReset { get; private set; }
        public DateTime TimeToReset { get; private set; }
        public int InitialSecondsToReset { get; private set; }
        public int InitialRemainingRequests { get; private set; }

        public RateLimiter(int remainingRequests = 1, int resetTime = 1)
        {
            setRateLimiter(remainingRequests, resetTime);
            InitialRemainingRequests = remainingRequests;
            InitialSecondsToReset = resetTime;
        }

        public void setRateLimiter(int remainingRequests = 1, int resetTime = 1)
        {
            RemainingRequests = remainingRequests;
            SecondsToReset = resetTime;
            TimeToReset = DateTime.UtcNow.AddSeconds(SecondsToReset);
        }
        public async Task<bool> CanMakeRequestAsync()
        {
            //smoothly limit requests once we are within 20% of the limit
            bool isRequestWithinRequestRatio = RemainingRequests < 1 ? false : RemainingRequests > (InitialRemainingRequests * 0.2) ? true : (RemainingRequests / SecondsToReset ) >= (InitialRemainingRequests/InitialSecondsToReset);
                                                                                    
                return isRequestWithinRequestRatio || TimeToReset <= DateTime.UtcNow ;
        }

        public async Task RecordRequestAsync(int remainingRequests)
        {
            RemainingRequests = remainingRequests;
        }

       
    }

}
