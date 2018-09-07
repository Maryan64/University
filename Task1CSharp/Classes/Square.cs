using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1CSharp.Interfaces;

namespace Task1CSharp.Classes
{
    public class Square : IFigure
    {
        #region Properties
        public Point TopLeft { get; set; } = new Point();
        public Point BottomRight { get; set; } = new Point();
        public double Side => TopLeft.Y - BottomRight.Y;
        #endregion

        #region IShape
        public double Area()
        {
            return Math.Pow(Side, 2);
        }

        public double Perimeter()
        {
            return Side * 4;
        }
        #endregion

        #region IFileManager
        public void Read(StreamReader sr)
        {
            string[] fields = sr.ReadLine().Split(' ');
            TopLeft.X = Convert.ToDouble(fields[0]);
            TopLeft.Y = Convert.ToDouble(fields[1]);
            BottomRight.X = Convert.ToDouble(fields[2]);
            BottomRight.Y = Convert.ToDouble(fields[3]);
        }

        public void Write(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
        #endregion

        public override string ToString()
        {
            return $"{nameof(Square)} with {nameof(TopLeft)}: {TopLeft.ToString()} and {nameof(BottomRight)}: {BottomRight.ToString()}";
        }
    }
}
