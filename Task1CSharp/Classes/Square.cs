﻿using System;
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
        /// <summary>
        /// Method to calculate square area
        /// </summary>
        /// <returns>square area</returns>
        public double Area()
        {
            return Math.Pow(Side, 2);
        }

        /// <summary>
        /// Method to calculate square perimeter
        /// </summary>
        /// <returns>Square perimeter</returns>
        public double Perimeter()
        {
            return Side * 4;
        }

        /// <summary>
        /// Calculates if the square belongs to third quater
        /// </summary>
        /// <returns> True if square belongs to third quater </returns>       
        public bool InThirdQuater()
        {
            if (TopLeft.X <= 0 && TopLeft.Y <= 0)
            {
                if (BottomRight.X <= 0 && BottomRight.Y <= 0)
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
                TopLeft.X = Convert.ToDouble(fields[0]);
                TopLeft.Y = Convert.ToDouble(fields[1]);
                BottomRight.X = Convert.ToDouble(fields[2]);
                BottomRight.Y = Convert.ToDouble(fields[3]);
                 if ((TopLeft.Y <= BottomRight.Y || TopLeft.X >= BottomRight.X) ||
                    (Math.Abs(TopLeft.X - BottomRight.X) != Math.Abs(TopLeft.Y - BottomRight.Y)))
                {
                    Log.Message($"Invalid square coordinates {ToString()}");

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
            return $"{nameof(Square)} with {nameof(TopLeft)}: {TopLeft.ToString()} and {nameof(BottomRight)}: {BottomRight.ToString()}; Area: {Area():0.##}; Perimeter: {Perimeter():0.##}";
        }
    }
}
