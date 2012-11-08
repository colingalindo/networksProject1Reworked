using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace networksProject1
{
    public struct DV
    {
        public DV(int d, int c) { destination = d; cost = c; }
        public int destination;
        public int cost;
    }

    public class DVPacket
    {
        private Dictionary<int, DV> dvTable;

        public DVPacket()
        {
            dvTable = new Dictionary<int,DV>();
        }

        public void addRow(int d, int c)
        {
            DV tmpDV = new DV(d, c);
	        dvTable.Add(d, tmpDV);
        }

        public Dictionary<int, DV> getDV()
        {
	        return dvTable;
        }

    }
}
