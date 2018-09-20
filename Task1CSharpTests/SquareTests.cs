using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xunit;
using Task1CSharp.Classes;

namespace Task1CSharpTests
{
   public class SquareTests
    {
        private const string READ = "../../../SquareRead.txt";
        private const string WRITE = "../../../SquareWrite.txt";
        private Square square;
        private Point topLeftPoint; 
        private Point bottomRightPoint;

        public SquareTests()
        {
            topLeftPoint = new Point() { X = 0, Y = 4 };
            bottomRightPoint = new Point() { X = 4, Y = 0 };
            square = new Square() { TopLeft = topLeftPoint, BottomRight = bottomRightPoint };
        }

        [Fact]
        public void PerimeterTest()
        {
            ////ACT
            double perimeter = square.Side * 4;
            ////ASSERT
            Assert.Equal(perimeter, square.Perimeter());
        }

        [Fact]
        public void AreaTest()
        {
            ////ACT
            double area = square.Side * square.Side;
            ////ASSERT
            Assert.Equal(area, square.Area());
        }

        [Fact]
        public void Read()
        {
            ////ACT
            Square sq;
            using (StreamReader sr = new StreamReader(READ, Encoding.Default))
            {
                sq = new Square();
                sq.Read(sr);
            }

            string expected = "0110";
            string real = sq.TopLeft.X.ToString() + sq.TopLeft.Y.ToString() +
                sq.BottomRight.X.ToString() + sq.BottomRight.Y.ToString();
            ////ASSERT
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

        [Fact]
        public void ThirdQuaterTest()
        {
            ////ACT

            Square squareFirstQuarter = new Square()
            {
                BottomRight = new Point() { X = 3, Y = 5 },
                TopLeft = new Point() { X = 10, Y = 1 }
            };
            Square squareSecondQuarter = new Square()
            {
                BottomRight = new Point() { X = -3, Y = 5 },
                TopLeft = new Point() { X = -10, Y = 1 }
            };
            Square squareThirdQuarter = new Square()
            {
                BottomRight = new Point() { X = -3, Y = -5 },
                TopLeft = new Point() { X = -10, Y = -1 }
            };
            Square squareFourthQuarter = new Square()
            {
                BottomRight = new Point() { X = 3, Y = -5 },
                TopLeft = new Point() { X = 10, Y = -1 }
            };
           ////ASSERT
            Assert.False(squareFirstQuarter.InThirdQuater());
            Assert.False(squareSecondQuarter.InThirdQuater());
            Assert.True(squareThirdQuarter.InThirdQuater());
            Assert.False(squareFourthQuarter.InThirdQuater());
        }
    }
   }
