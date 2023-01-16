using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParseJson
{
    public class Classes
    {
        public class BoundingPoly
    {
        public List<Vertex> vertices { get; set; }
    }

    public class Response
    {
        public string locale { get; set; }
        public string description { get; set; }
        public BoundingPoly boundingPoly { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    }
}