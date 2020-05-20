using System;
using System.Collections.Generic;
using System.Text;

namespace BellmanFord
{
    public class Edge
    {
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }
        public int Weight { get; set; }

        public void Relax()
        {
            if (Destination.Distance > (Source.Distance + Weight))
                Destination.Distance = Source.Distance + this.Weight;
        }
        public override string ToString()
        {
            return Source + "->" + Destination + "(" + Weight + ")";
        }
    }
}
