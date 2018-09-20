using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1CSharp.Interfaces;

namespace Task1CSharp.Classes
{
    /// <summary>
    /// Circle class
    /// </summary>
    public class Circle : IFigure
    {
        private const double PI = 3.14;

        #region Properties
        public Point Center { get; set; } = new Point();
        public double Radius { get; set; }
        #endregion

        #region IShape
        /// <summary>
        /// Method to calculate circle perimeter
        /// </summary>
        /// <returns>circle perimeter</returns>
        public double Perimeter()
        {
            return 2 * PI * Radius;
        }        

        /// <summary>
        /// Method to calculate circle area
        /// </summary>
        /// <returns>circle area</returns>
        public double Area()
        {
            return PI * Radius * Radius;
        }

        /// <summary>
        /// Calculates if the circle belongs to third quater
        /// </summary>
        /// <returns>True if circle belongs to third quater</returns>
        public bool InThirdQuater()
        {
            if (Center.X < 0 && Center.Y < 0)
            {
                if (Math.Abs(Center.X) >= Radius && Math.Abs(Center.Y) >= Radius)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                Center.X = Convert.ToDouble(fields[0]);
                Center.Y = Convert.ToDouble(fields[1]);
                Radius = Convert.ToDouble(fields[2]);

                if (Radius <= 0)
                {
                    Log.Message($"Invalid circle radius {ToString()}");
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
        /// <returns>Converted string</returns>
        public override string ToString()
        {
            return $"{nameof(Circle)} with {nameof(Center)}: {Center.ToString()} and {nameof(Radius)}: {Radius}; Area: {Area():0.##}; Perimeter: {Perimeter():0.##}";
        }
    }
}
