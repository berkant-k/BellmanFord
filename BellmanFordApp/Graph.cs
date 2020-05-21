using System;
using System.Collections.Generic;

namespace BellmanFord
{
    public class Graph
    {

        public List<Edge> Edges { get; private set; }
        public List<Vertex> Vertices { get; private set; }

        public Graph()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
        }
        public void Print()
        {
            Console.WriteLine("Vertex \t Distance from source");

            foreach (var item in Vertices)
            {
                Console.WriteLine("{0}\t {1}", item.Id, item.Distance);
            }

        }
    }

}
