using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LSCollections;
using System.Collections;

namespace networksProject1
{
    public partial class Form1 : Form
    {
        IComparer myComparer;
        PriorityQueue queue;
        bool tablesInit;

        public struct link
        {
            public link(int s, int d, int c, double de) { source = s; destination = d; cost = c; delay = de; }
            public int source;
            public int destination;
            public int cost;
            public double delay;
        }

        public class myCompareClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                Event e1 = (Event)x;
                Event e2 = (Event)y;
                if (e1.time < e2.time)
                    return 1;
                if (e1.time > e2.time)
                    return -1;
                else
                    return 0;
            }
        }

        Dictionary<int, Node> nodes;
        public Form1()
        {
            InitializeComponent();
            nodes = new Dictionary<int, Node>();
            myComparer = new myCompareClass();
            queue = new PriorityQueue(myComparer);
            tablesInit = false;
        }

        private void runSim_Click(object sender, EventArgs e)
        {
            if (!tablesInit)
                initializeTables();
            //if (initializeTables())
            //{
                Dictionary<int, NT> tmpNT = new Dictionary<int, NT>();
                int lastNodeToConverge = -1;
                int numUpdates = 0;
                double convergeTime = -1;
                int periodicUpdateTime = 0;
                bool converged = false;
                while (!converged)
                {
                    for (int i = 0; i < nodes.Count; ++i)
                    {
                        tmpNT = nodes[i].getNeighborTable();
                        foreach (KeyValuePair<int, NT> tmp in tmpNT)
                        {
                            nodes[i].addEvent(ref queue, 1, tmp.Value.destination, tmp.Value.delay);
                        }
                    }
                    periodicUpdateTime++;
                    while (queue.Count > 0)
                    {
                        Event tmpEvent = (Event)queue.Peek();
                        if ((tmpEvent.eventType == 1) || (tmpEvent.eventType == 2))
                            numUpdates++;
                        if (tmpEvent.eventType == 2)
                            lastNodeToConverge = tmpEvent.sourceIP;
                        convergeTime = tmpEvent.time;
                        nodes[tmpEvent.destinationIP].processEvent(ref queue);
                    }
                    converged = networkConverged(queue);
                }
                printTables();
                Console.WriteLine("Time to converge: " + convergeTime);
                Console.WriteLine("Last node to converge: " + lastNodeToConverge);
                Console.WriteLine("Number of Periodic and Triggered updates: " + numUpdates);
            //}
        }

        private bool initializeTables()
        {
            int source;
            int destination;
            int cost;
            double delay;
            string[] lines = File.ReadAllLines(fileName.Text);
            string[] splitLine;
            List<link> tmpList = new List<link>();
            Node tmpNode = new Node();
            HashSet<int> numNodes = new HashSet<int>();
            foreach (string line in lines)
            {
                splitLine = line.Split('\t');
                source = Convert.ToInt32(splitLine[0]);
                destination = Convert.ToInt32(splitLine[1]);
                cost = Convert.ToInt32(splitLine[2]);
                delay = Convert.ToDouble(splitLine[3]);
                link tmpLink = new link(source, destination, cost, delay);
                tmpList.Add(tmpLink);
                numNodes.Add(source);
                numNodes.Add(destination);
            }

            foreach (int num in numNodes)
            {
                tmpNode = new Node();
                tmpNode.setAddress(num);
                nodes.Add(num, tmpNode);
            }

            foreach (link tmpLink in tmpList)
            {
                nodes[tmpLink.source].addRoute(tmpLink.destination, tmpLink.cost, tmpLink.destination);
                nodes[tmpLink.source].addNeighbor(tmpLink.destination, tmpLink.cost, tmpLink.delay);
                
                nodes[tmpLink.destination].addRoute(tmpLink.source, tmpLink.cost, tmpLink.source);
                nodes[tmpLink.destination].addNeighbor(tmpLink.source, tmpLink.cost, tmpLink.delay);
            }
            tablesInit = true;
            return true;
        }

        private void printTables()
        {
            Dictionary<int, RT> tmpRT = new Dictionary<int, RT>();
            for (int i = 0; i < nodes.Count; ++i)
            {
                Console.WriteLine("Nodes: " + nodes[i].getAddress());
                tmpRT = nodes[i].getRoutingTable();
                foreach (KeyValuePair<int, RT> tmp in tmpRT)
                {
                    Console.WriteLine("\tDestination: " + tmp.Value.destination + "\tCost: " + tmp.Value.cost + "\tNext Hop: " + tmp.Value.nextHop);
                }
            }
        }

        private void debug(Event tmpEvent)
        {
            Console.WriteLine("Time: " + tmpEvent.time);
            Console.WriteLine("Source: " + tmpEvent.sourceIP);
            Console.WriteLine("Destination: " + tmpEvent.destinationIP);
            Console.WriteLine("Type: " + tmpEvent.eventType);
            foreach (KeyValuePair<int, DV> tmp in tmpEvent.packet.getDV())
            {
                Console.WriteLine("\tDestination: " + tmp.Value.destination + "\tCost: " + tmp.Value.cost);
            }
        }

        private bool networkConverged(PriorityQueue queue)
        {
            Event tmpEvent;
            while (queue.Count > 0)
            {
                tmpEvent = (Event)queue.Dequeue();
                if ((tmpEvent.eventType == 2) || (tmpEvent.eventType == 3) || (tmpEvent.eventType == 4))
                {
                    return false;
                }
            }
            return true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            if ((eventTypeBox.Text == "") || (timeBox.Text == "") || (sNodeBox.Text == "") || (dNodeBox.Text == ""))
            {
                return;
            }

            int source = Convert.ToInt32(sNodeBox.Text);
            int destination = Convert.ToInt32(sNodeBox.Text);
            int eventType = Convert.ToInt32(eventTypeBox.Text);
            double time = Convert.ToDouble(timeBox.Text);

            initializeTables();

            if (eventType == 3)
            {
                nodes[source].addEvent(ref queue, eventType, destination, time);
                nodes[destination].addEvent(ref queue, eventType, source, time);
            }
            if (eventType == 4)
            {
                nodes[source].addEvent(ref queue, eventType, -1, time, destination);
            }

            Console.WriteLine("Event Added");
        }
    }
}
