using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Lib
{
    public class SubscriberC : ISubscriber
    {
        public void update(string eventname)
        {
            Console.WriteLine($"Subscriber: C, Event: {eventname}");
        }
    }
}
