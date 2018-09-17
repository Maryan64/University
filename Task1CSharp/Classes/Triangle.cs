using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1CSharp.Interfaces;

namespace Task1CSharp.Classes
{
    public class Triangle : IFigure
    {
        #region Properties
        public Point A { get; set; } = new Point();
        public Point B { get; set; } = new Point();
        public Point C { get; set; } = new Point();
        public double AB => Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        public double AC => Math.Sqrt(Math.Pow(C.X - A.X, 2) + Math.Pow(C.Y - A.Y, 2));
        public double BC => Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));
        #endregion

        #region IShape
        public double Area()
        {
            return Math.Sqrt(Perimeter() / 2 * (Perimeter()/2-AB) * (Perimeter() / 2 - BC) * (Perimeter() / 2 - AC));
        }

        public double Perimeter()
        {
            return AB + AC + BC;
        }
        #endregion

        #region IFileManager
        public void Read(StreamReader sr)
        {
            string[] fields = sr.ReadLine().Split(' ');
            A.X = Convert.ToDouble(fields[0]);
            A.Y = Convert.ToDouble(fields[1]);
            B.X = Convert.ToDouble(fields[2]);
            B.Y = Convert.ToDouble(fields[3]);
            C.X = Convert.ToDouble(fields[4]);
            C.Y = Convert.ToDouble(fields[5]);
        }

        public void Write(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
        #endregion

        public override string ToString()
        {
            return $"{nameof(Triangle)} with {nameof(A)}: {A.ToString()} and {nameof(B)}: {B.ToString()} and {nameof(C)}: {C.ToString()}";
        }
    }
}
