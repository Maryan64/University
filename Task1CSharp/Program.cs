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
    class Program
    {
        private const string READ_PATH = "../../read.txt";
        private const string WRITE_PATH = "../../write.txt";

        public static void Main(string[] args)
        {
            List<IFigure> list = ReadFiguresFromFile();
            WriteFiguresToFile(list);

            Console.ReadLine();
        }

        public static List<IFigure> ReadFiguresFromFile()
        {
            List<IFigure> list = new List<IFigure>();

            using (StreamReader sr = new StreamReader(READ_PATH, Encoding.Default))
            {
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
                        figure.Read(sr);
                        list.Add(figure);
                    }                   
                }
            }

            return list;
        }

        public static void WriteFiguresToFile(List<IFigure> list)
        {
            using (StreamWriter sw = new StreamWriter(WRITE_PATH, true, Encoding.Default))
            {
                foreach (var item in list)
                {
                    item.Write(sw);
                }
            }
        }
    }
}
