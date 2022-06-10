using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingClock
{
    public class Publisher
    {
        protected List<ISubscriber> subscribers = new List<ISubscriber>();

        public void AddSubcriber(ISubscriber sub)
        {
            subscribers.Add(sub);
        }

        public void PublishMessage(string message)
        {
            foreach (ISubscriber subscriber in subscribers)
            {
                subscriber.ReceiveMessage(message);
            }
        }
    }
}
