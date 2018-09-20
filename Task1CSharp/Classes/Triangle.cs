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
        /// <summary>
        /// Method to calculate triangle area
        /// </summary>
        /// <returns>triangle area</returns>
        public double Area()
        {
            return Math.Sqrt(Perimeter() / 2 * (Perimeter() / 2 - AB) * (Perimeter() / 2 - BC) * (Perimeter() / 2 - AC));
        }

        /// <summary>
        /// Method to calculate triangle perimeter
        /// </summary>
        /// <returns> Triangle perimeter </returns>
        public double Perimeter()
        {
            return AB + AC + BC;
        }

        /// <summary>
        /// Calculates if the triangle belongs to third quater
        /// </summary>
        /// <returns> True if triangle belongs to third quater </returns>
        public bool InThirdQuater()
        {
            if (A.X <= 0 && A.Y <= 0 && B.X <= 0 && B.Y <= 0 && C.X <= 0 && C.Y <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region IFileManager
        /// <summary>
        /// Read and writes all data from "sr" to object propertis
        /// </summary>
        /// <param name="sr"> stream reader </param>
        /// <returns> is object initialize valid </returns>
        public bool Read(StreamReader sr)
        {
            string[] fields = sr.ReadLine().Split(' ');
            try
            {
                A.X = Convert.ToDouble(fields[0]);
                A.Y = Convert.ToDouble(fields[1]);
                B.X = Convert.ToDouble(fields[2]);
                B.Y = Convert.ToDouble(fields[3]);
                C.X = Convert.ToDouble(fields[4]);
                C.Y = Convert.ToDouble(fields[5]);

                if ((B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X) == 0)
                {
                    Log.Message($"Invalid sides of triangle {ToString()}");
                    return false;
                }

                return true;
            }
            catch (FormatException ex)
            {
                Log.Message(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Message(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Writes all objects data to "sw"
        /// </summary>
        /// <param name="sw"> stream writer </param>
        public void Write(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }
        #endregion

        /// <summary>
        /// Converts data to user friendly view
        /// </summary>
        /// <returns> Converted string </returns>
        public override string ToString()
        {
            return $"{nameof(Triangle)} with {nameof(A)}: {A.ToString()} and {nameof(B)}: {B.ToString()} and {nameof(C)}: {C.ToString()}; Area: {Area():0.##}; Perimeter: {Perimeter():0.##}";
        }
    }
}
