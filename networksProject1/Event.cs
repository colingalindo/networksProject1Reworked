using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace networksProject1
{
    public struct Event
    {
        public Event(double t, int eT, int sIP, int dIP, DVPacket p) { time = t; eventType = eT; sourceIP = sIP; destinationIP = dIP; packet = p; }
        public Event(double t, int eT, int sIP, int dIP, int dp) { time = t; eventType = eT; sourceIP = sIP; destinationIP = dIP; dataPakcetDestination = dp; }
        public double time;
        public int eventType;
        public int sourceIP;
        public int destinationIP;
        public int dataPakcetDestination;
        public DVPacket packet;
    }
}
