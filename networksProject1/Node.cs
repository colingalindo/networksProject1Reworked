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
            bool changed = false;
            if ((tmpEvent.eventType == 1) || (tmpEvent.eventType == 2))
            {
                int newCost = 0;
                RT tmpRT = new RT();
                foreach (KeyValuePair<int, DV> tmpDV in tmpEvent.packet.getDV())
                {
                    if (tmpDV.Value.cost == -1)
                    {
                        routingTable.Remove(tmpDV.Value.destination);
                        if(neighborTable.ContainsKey(tmpDV.Value.destination))
                        {
                            tmpRT.destination = tmpDV.Value.destination;
                            tmpRT.cost = neighborTable[tmpDV.Value.destination].cost;
                            tmpRT.nextHop = tmpDV.Value.destination;
                            routingTable.Add(tmpDV.Value.destination, tmpRT);
                            changed = true;
                        }
                    }
                    else
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
                            if ((routingTable[tmpDV.Value.destination].cost > newCost)||(routingTable[tmpDV.Value.destination].cost == -1))
                            {
                                routingTable.Remove(tmpDV.Value.destination);
                                routingTable.Add(tmpDV.Value.destination, tmpRT);
                                changed = true;
                            }
                        }
                    }
                }
            }
            if (tmpEvent.eventType == 3)
            {
                RT tmpRT = new RT( tmpEvent.sourceIP, -1, routingTable[tmpEvent.sourceIP].nextHop);
                routingTable.Remove(tmpEvent.sourceIP);
                routingTable.Add(tmpEvent.sourceIP, tmpRT);
                changed = true;
            }
            if (tmpEvent.eventType == 4)
            {
                if (address == tmpEvent.dataPacketDestination)
                {
                    Console.WriteLine("Packet received from " + tmpEvent.sourceIP + " at " + tmpEvent.time);
                }
                else
                {
                    foreach (KeyValuePair<int, RT> tmpRT in routingTable)
                    {
                        //Console.WriteLine("Event type 4");
                        //Console.WriteLine("RT destination: " + tmpRT.Value.destination);
                        //Console.WriteLine("Data Packet dest: " + tmpEvent.dataPacketDestination);
                        if (tmpRT.Value.destination == tmpEvent.dataPacketDestination)
                        {
                            addEvent(ref queue, 4, tmpRT.Value.nextHop, tmpEvent.time + neighborTable[tmpRT.Value.nextHop].delay, tmpEvent.dataPacketDestination);
                            Console.WriteLine("Sending data packet to " + tmpRT.Value.nextHop + " from " + address + " at time " + tmpEvent.time);
                        }
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
