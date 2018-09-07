using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1CSharp.Classes
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
