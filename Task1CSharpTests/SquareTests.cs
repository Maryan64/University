using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.IO;
using Task1CSharp.Classes;
namespace Task1CSharpTests
{
   public class SquareTests
    {
        private Square square;
        private Point topLeftPoint;
        private Point bottomRightPoint;
        private const string READ = "../../../SquareRead.txt";
        private const string WRITE = "../../../SquareWrite.txt";
        public SquareTests()
        {
            topLeftPoint = new Point() { X = 0, Y = 4 };
            bottomRightPoint = new Point() { X = 4, Y = 0 };
            square = new Square() { TopLeft = topLeftPoint, BottomRight = bottomRightPoint };
        }
        [Fact]
        public void PerimeterTest()
        {
            //act
            double perimeter = square.Side * 4;
            //assert
            Assert.Equal(perimeter, square.Perimeter());
        }
        [Fact]
        public void AreaTest()
        {
            //act
            double area = square.Side * square.Side;
            //assert
            Assert.Equal(area, square.Area());
        }
        [Fact]
        public void Read()
        {
            //act
            Square sq;
            using (StreamReader sr = new StreamReader(READ, Encoding.Default))
            {
                sq = new Square();
                sq.Read(sr);
            }
            string expected = "0110";
            string real = sq.TopLeft.X.ToString()+sq.TopLeft.Y.ToString()+
                sq.BottomRight.X.ToString() + sq.BottomRight.Y.ToString();
            //assert
            Assert.Equal(expected, real);
        }
        [Fact]
        public void Write()
        {
            using (StreamWriter sw = new StreamWriter(WRITE, false, Encoding.Default))
            {
                square.Write(sw);
            }
            using (StreamReader sr = new StreamReader(WRITE, Encoding.Default))
            {
                Assert.Equal(square.ToString(), sr.ReadLine());
            }
        }
    }
}
