using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BellmanFordImplementation
{
    class BellmanFordShortesPath
    {
        public class Vertex
        {
            public string Id { get; set; }
            public int Distance { get; set; }

            public Vertex(string id) => Id = id;

            public override string ToString()
            {
                return Id + "(" + Distance + ")"; ;
            }
        }
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

        public class Graph
        {

            public List<Edge> Edges;
            public List<Vertex> Vertices;

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




        public static bool BellmanFord(Graph graph, Vertex source)
        {

            foreach (var v in graph.Vertices)
            {
                v.Distance = int.MaxValue;
            }

            source.Distance = 0;
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                Console.WriteLine($"Iteration={i} ");
                graph.Print();
                Console.WriteLine("-------------");
                foreach (var edge in graph.Edges)
                {
                    edge.Relax();
                }                
            }
            return !graph.Edges.Any(p => p.Destination.Distance > p.Source.Distance + p.Weight);     //negatif döngü kontrolü     
        }



        static void Main(string[] args)
        {

            Graph graph = new Graph();


            var s = new Vertex("s");
            var y = new Vertex("y");
            var x = new Vertex("x");
            var z = new Vertex("z");
            var t = new Vertex("t");          
            graph.Vertices.Add(s);
            graph.Vertices.Add(y);
            graph.Vertices.Add(x);
            graph.Vertices.Add(z);
            graph.Vertices.Add(t);

            graph.Edges.Add(new Edge { Source = s, Destination = t, Weight = 6 });
            graph.Edges.Add(new Edge { Source = s, Destination = y, Weight = 7 });

            graph.Edges.Add(new Edge { Source = t, Destination = x, Weight = 5 });
            graph.Edges.Add(new Edge { Source = t, Destination = z, Weight = -4 });
            graph.Edges.Add(new Edge { Source = t, Destination = y, Weight = 8 });

            graph.Edges.Add(new Edge { Source = y, Destination = z, Weight = 9 });
            graph.Edges.Add(new Edge { Source = y, Destination = x, Weight = -3 });

            graph.Edges.Add(new Edge { Source = z, Destination = s, Weight = 2 });
            graph.Edges.Add(new Edge { Source = z, Destination = x, Weight = 7 });

            graph.Edges.Add(new Edge { Source = x, Destination = t, Weight = -2 });

            var result = BellmanFord(graph, s);

            Console.WriteLine(result);

            Console.WriteLine("-------------------");
            Console.WriteLine("Final Graph");
            Console.WriteLine("-------------------");

            graph.Print();

            Console.ReadKey();



        }
    }
}