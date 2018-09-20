using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1CSharp.Classes;
using Task1CSharp.Interfaces;

namespace Task1CSharp
{
    public class Program
    {
        private const string READ_PATH = "../../read.txt";
        private const string WRITE_PATH_FILE1 = "../../file1.txt";
        private const string WRITE_PATH_FILE2 = "../../file2.txt";

        public static void Main(string[] args)
        {
            try
            {
                List<IFigure> list = ReadFiguresFromFile();
                SortByArea(list);
                SortByPerimeter(list);
            }
            catch (FileNotFoundException ex)
            {
                Log.Message(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Message(ex.Message);
            }
            
            Console.ReadLine();
        }

            /// <summary>
            /// Reads a file "read.txt"
            /// </summary>
            /// <returns> List filled with Figures </returns>
            public static List<IFigure> ReadFiguresFromFile()
        {
            List<IFigure> list = new List<IFigure>();

            using (StreamReader sr = new StreamReader(READ_PATH, Encoding.Default))
            {
                Log.Message($"Begin read from {READ_PATH}");
                while (!sr.EndOfStream)
                {
                    string type = sr.ReadLine();
                    type = type.Trim();
                    IFigure figure = null;
                    if (type == FigureType.Circle.ToString())
                    {
                        figure = new Circle();                        
                    }
                    else if (type == FigureType.Square.ToString())
                    {
                        figure = new Square();
                    }
                    else if (type == FigureType.Triangle.ToString())
                    {
                        figure = new Triangle();
                    }

                    if (figure != null)
                    {
                        if (figure.Read(sr))
                        {
                            list.Add(figure);
                        }
                    }                   
                }

                Log.Message($"End read from {READ_PATH}");
            }

            return list;
        }

        /// <summary>
        /// Writes data from "list" to file "WRITE_PATH"
        /// </summary>
        /// <param name="WRITE_PATH"> String path </param>
        /// <param name="list"> List of figures </param>
        public static void WriteFiguresToFile(string WRITE_PATH, List<IFigure> list)
        {
            using (StreamWriter sw = new StreamWriter(WRITE_PATH, false, Encoding.Default))
            {
                Log.Message($"Begin write to {WRITE_PATH}");
                foreach (var item in list)
                {
                    item.Write(sw);
                }

                Log.Message($"End write to {WRITE_PATH}");
            }
        }

        /// <summary>
        /// Writes sorted by area list to file "WRITE_PATH_FILE1"
        /// </summary>
        /// <param name="list"> List of figures </param>
        public static void SortByArea(List<IFigure> list)
        {
            List<IFigure> listSortedByArea = new List<IFigure>();
            listSortedByArea = (from t in list
                                orderby t.Area()
                                select t).ToList();
            WriteFiguresToFile(WRITE_PATH_FILE1, listSortedByArea);
        }

        /// <summary>
        /// Writes sorted by perimeter list to file "WRITE_PATH_FILE2"
        /// </summary>
        /// <param name="list"> list of figures </param>
        public static void SortByPerimeter(List<IFigure> list)
        {
            List<IFigure> listSortedByPerimeneter = new List<IFigure>();
            listSortedByPerimeneter = (from t in list
                                       where t.InThirdQuater()
                                       orderby t.Perimeter() descending
                                       select t).ToList();
            WriteFiguresToFile(WRITE_PATH_FILE2, listSortedByPerimeneter);
        }
    }
}
