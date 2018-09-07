using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1CSharp.Interfaces;

namespace Task1CSharp.Classes
{
    public class Circle : IFigure
    {
        private const double PI = 3.14;

        #region Properties
        public Point Center { get; set; } = new Point();
        public double Radius { get; set; }
        #endregion

        #region IShape
        public double Perimeter()
        {
            return 2 * PI * Radius;
        }        

        public double Area()
        {
            return PI * Radius * Radius;
        }
        #endregion

        #region IFileManager
        public void Read(StreamReader sr)
        {
            string[] fields = sr.ReadLine().Split(' ');
            Center.X = Convert.ToDouble(fields[0]);
            Center.Y = Convert.ToDouble(fields[1]);
            Radius = Convert.ToDouble(fields[2]);
        }

        public void Write(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
        #endregion

        public override string ToString()
        {
            return $"{nameof(Circle)} with {nameof(Center)}: {Center.ToString()} and {nameof(Radius)}: {Radius}";
        }
    }
}
