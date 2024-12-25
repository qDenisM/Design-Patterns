using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Lib
{
    public class SubscriberB : ISubscriber
    {
        public void update(string eventname)
        {
            Console.WriteLine($"Subscriber: B, Event: {eventname}");
        }
    }
}
