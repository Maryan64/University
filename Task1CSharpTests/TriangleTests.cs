using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task1CSharp.Classes;
using Xunit;

namespace Task1CSharpTests
{
    public class TriangleTests
    {
        private const string READ = "../../../TriangleRead.txt";
        private const string WRITE = "../../../TriangleWrite.txt";
        private Triangle triangle;
        private Point First;
        private Point Second;
        private Point Third;

        public TriangleTests()
        {
            First = new Point() { X = 0, Y = 0 };
            Second = new Point() { X = 3, Y = 3 };
            Third = new Point() { X = 5, Y = 0 };
            triangle = new Triangle() { A = First, B = Second, C = Third };
        }

        [Fact]
        public void PerimeterTest()
        {
            //Act
            double result = triangle.Perimeter();
            double expected = triangle.AB + triangle.BC + triangle.AC;

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public void AreaTest()
        {
            //Act
            double result = triangle.Area();
            double p = triangle.Perimeter() / 2;
            double a = triangle.AB;
            double b = triangle.BC;
            double c = triangle.AC;
            double expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ReadTest()
        {
            //Act
            Triangle validTriangle = new Triangle();
            Triangle invalidTriangle = new Triangle();
            bool validResult;
            bool invalidResult;
            using (StreamReader sr = new StreamReader(READ, Encoding.Default))
            {
                validResult = validTriangle.Read(sr);
                invalidResult = invalidTriangle.Read(sr);
            }

            Assert.Equal(0, validTriangle.A.X);
            Assert.Equal(1, validTriangle.A.Y);
            Assert.Equal(2, validTriangle.B.X);
            Assert.Equal(3, validTriangle.B.Y);
            Assert.Equal(4, validTriangle.C.X);
            Assert.Equal(9, validTriangle.C.Y);
            Assert.True(validResult);
            Assert.False(invalidResult);
        }

        [Fact]
        public void WriteTest()
        {
            using (StreamWriter sw = new StreamWriter(WRITE, false, Encoding.Default))
            {
                sw.Write(triangle);
            }

            using (StreamReader sr = new StreamReader(WRITE, Encoding.Default))
            {
                Assert.Equal(triangle.ToString(), sr.ReadLine());
            }
        }

        [Fact]
        public void ThirdQuaterTest()
        {
            //ACT
            Triangle inFirstQuarter = new Triangle { A = new Point { X = 1, Y = 1 }, B = new Point { X = 2, Y = 2 }, C = new Point { X = 3, Y = 3 } };
            Triangle inSecondQuarter = new Triangle { A = new Point { X = -1, Y = 1 }, B = new Point { X = -2, Y = 2 }, C = new Point { X = -3, Y = 3 } };
            Triangle inThirdQuarter = new Triangle { A = new Point { X = -1, Y = -1 }, B = new Point { X = -2, Y = -2 }, C = new Point { X = -3, Y = -3 } };
            Triangle inFourthQuarter = new Triangle { A = new Point { X = 1, Y = -1 }, B = new Point { X = 2, Y = -2 }, C = new Point { X = 3, Y = -3 } };

            //ASSERT
            Assert.False(inFirstQuarter.InThirdQuater());
            Assert.False(inSecondQuarter.InThirdQuater());
            Assert.True(inThirdQuarter.InThirdQuater());
            Assert.False(inFourthQuarter.InThirdQuater());
        }
    }
}
