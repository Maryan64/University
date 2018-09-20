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

        /// <summary>
        /// Convers data to user friendly view
        /// </summary>
        /// <returns>Converted string</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
