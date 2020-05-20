using System;

namespace BellmanFord
{
    class Program
    {
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

            var success = ShortestPath.BellmanFord(graph, s);


            Console.WriteLine("-------------------");
            Console.WriteLine($"Source={s.Id},Negative Success={success}, Final Table");
            Console.WriteLine("-------------------");

            graph.Print();

            Console.ReadKey();



        }
    }
}