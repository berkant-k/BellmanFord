using System;
using System.Collections.Generic;
using System.Text;

namespace BellmanFord
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
}
