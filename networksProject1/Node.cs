using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LSCollections;

namespace networksProject1
{
    public struct RT
    {
        public RT(int d, int c, int nH) { destination = d; cost = c; nextHop = nH; }
        public int destination;
        public int cost;
        public int nextHop;
    }

    public struct NT
    {
        public NT(int d, int c, double de) { destination = d; cost = c; delay = de; }
        public int destination;
        public int cost;
        public double delay;
    }

    public class Node
    {
        private int address;
        private Dictionary<int, RT> routingTable;
        private Dictionary<int, NT> neighborTable;

        public Node()
        {
            routingTable = new Dictionary<int,RT>();
            neighborTable = new Dictionary<int,NT>();
            address = -1;
        }

        public void addRoute(int d, int c, int nH)
        {
            RT tmpRT = new RT(d, c, nH);
            routingTable.Add(d, tmpRT);
        }

        public void addNeighbor(int d, int c, double de)
        {
            NT tmpNT = new NT(d, c, de);
            neighborTable.Add(d, tmpNT);
        }

        public Dictionary<int, RT> getRoutingTable()
        {
            return routingTable;
        }

        public Dictionary<int, NT> getNeighborTable()
        {
            return neighborTable;
        }

        public void setAddress(int a)
        {
            address = a;
        }

        public int getAddress()
        {
            return address;
        }

        public void addEvent(ref PriorityQueue queue, int eT, int destNodeAdd, double t)
        {
            DVPacket tmpPacket;
	        //if((eT == 1)||(eT == 2))
		    tmpPacket = prepareDVPacket(destNodeAdd);
	
	        Event tmpEvent = new Event(t, eT, address, destNodeAdd, tmpPacket);
            queue.Enqueue(tmpEvent);
        }

        internal void addEvent(ref PriorityQueue queue, int eT, int p, double t, int d)
        {
            Event tmpEvent = new Event(t, eT, address, p, d);
            queue.Enqueue(tmpEvent);
        }

        public void processEvent(ref PriorityQueue queue)
        {
            Event tmpEvent = (Event)queue.Dequeue();
            if ((tmpEvent.eventType == 1) || (tmpEvent.eventType == 2))
            {
                bool changed = false;
                int newCost = 0;
                RT tmpRT = new RT();
                foreach (KeyValuePair<int, DV> tmpDV in tmpEvent.packet.getDV())
                {
                    newCost = tmpDV.Value.cost + neighborTable[tmpEvent.sourceIP].cost;
                    tmpRT.destination = tmpDV.Value.destination;
                    tmpRT.cost = newCost;
                    tmpRT.nextHop = tmpEvent.sourceIP;
                    if (!routingTable.ContainsKey(tmpDV.Value.destination))
                    {
                        routingTable.Add(tmpDV.Value.destination, tmpRT);
                        changed = true;
                    }
                    else
                    {
                        if(routingTable[tmpDV.Value.destination].cost > newCost)
                        {
                            routingTable.Remove(tmpDV.Value.destination);
                            routingTable.Add(tmpDV.Value.destination, tmpRT);
                            changed = true;
                        }
                    }
                }
                if (changed)
                {
                    foreach (KeyValuePair<int, NT> tmpNT in neighborTable)
                    {
                        addEvent(ref queue, 2, tmpNT.Value.destination, tmpEvent.time + tmpNT.Value.delay);
                    }
                }
            }
            if (tmpEvent.eventType == 3)
            {

            }
            if (tmpEvent.eventType == 4)
            {
                foreach (KeyValuePair<int, DV> tmpDV in tmpEvent.packet.getDV())
                {
                }
            }
        }

        private DVPacket prepareDVPacket(int d)
        {
            DVPacket packet = new DVPacket();

            foreach (KeyValuePair<int, RT> tmp in routingTable)
            {
                if ((tmp.Value.destination != d) && (tmp.Value.nextHop != d))
                    packet.addRow(tmp.Value.destination, tmp.Value.cost);
            }

            return packet;
        }
    }
}
