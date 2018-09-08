using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task1CSharp.Classes;
using Xunit;

namespace Task1CSharpTests
{
    public class CircleTests
    {
        private Circle circle;
        private double radius;
        private const double PI = 3.14;
        private const string READ_PATH = "../../../circleRead.txt";
        private const string WRITE_PATH = "../../../circleWrite.txt";

        public CircleTests()
        {
            radius = 4;
            circle = new Circle { Center = new Point { X = 0, Y = 0 }, Radius = radius };
        }

        [Fact] 
        public void PerimeterTest()
        {
            //Act
            var result = circle.Perimeter();
            var expected = 2 * PI * radius;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AreaTest()
        {
            //Act
            var result = circle.Area();
            var expected = PI * radius * radius;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadTest()
        {
            //Arange
            Circle c = null;

            //Act            
            using (StreamReader sr = new StreamReader(READ_PATH, Encoding.Default))
            {
                c = new Circle();
                c.Read(sr);
            }

            //Assert
            Assert.Equal(1, c.Center.X);
            Assert.Equal(2, c.Center.Y);
            Assert.Equal(4, c.Radius);
        }

        [Fact]
        public void Write()
        {
            //Act
            using (StreamWriter sw = new StreamWriter(WRITE_PATH, false, Encoding.Default))
            {
                sw.Write(circle);
            }

            //Assert
            using (StreamReader sr = new StreamReader(WRITE_PATH, Encoding.Default))
            {
                Assert.Equal(circle.ToString(), sr.ReadLine());
            }
        }
    }
}
