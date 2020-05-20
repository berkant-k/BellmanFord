using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BellmanFord
{
    public static class ShortestPath
    {
        public static bool BellmanFord(Graph graph, Vertex source)
        {
            foreach (var v in graph.Vertices)
            {
                v.Distance = int.MaxValue;
            }
            source.Distance = 0;
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                PrintDraft(graph, i + 1);//Just for testing 
                foreach (var edge in graph.Edges)
                {
                    edge.Relax();
                }
            }
            return !graph.Edges.Any(p => p.Destination.Distance > p.Source.Distance + p.Weight);     //negative cycle control
        }

        private static void PrintDraft(Graph graph, int iteration)
        {
            Console.WriteLine($"Iteration={iteration}");
            Console.WriteLine("-------------");
            graph.Print();
        }

    }
}
