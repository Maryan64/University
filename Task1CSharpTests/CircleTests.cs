using System.IO;
using System.Text;
using Task1CSharp.Classes;
using Xunit;

namespace Task1CSharpTests
{
    public class CircleTests
    {
        private const double PI = 3.14;
        private const string READ_PATH = "../../../circleRead.txt";
        private const string WRITE_PATH = "../../../circleWrite.txt";
        private Circle circle;
        private double radius;

        public CircleTests()
        {
            radius = 4;
            circle = new Circle { Center = new Point { X = 0, Y = 0 }, Radius = radius };
        }

        [Fact] 
        public void PerimeterTest()
        {
            ////Act
            var result = circle.Perimeter();
            var expected = 2 * PI * radius;

            ////Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AreaTest()
        {
            ////Act
            var result = circle.Area();
            var expected = PI * radius * radius;

            ////Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReadTest()
        {
            ////Arange
            Circle c = null;

            ////Act            
            using (StreamReader sr = new StreamReader(READ_PATH, Encoding.Default))
            {
                c = new Circle();
                c.Read(sr);
            }

            ////Assert
            Assert.Equal(1, c.Center.X);
            Assert.Equal(2, c.Center.Y);
            Assert.Equal(4, c.Radius);
        }

        [Fact]
        public void Write()
        {
            ////Act
            using (StreamWriter sw = new StreamWriter(WRITE_PATH, false, Encoding.Default))
            {
                sw.Write(circle);
            }

            ////Assert
            using (StreamReader sr = new StreamReader(WRITE_PATH, Encoding.Default))
            {
                Assert.Equal(circle.ToString(), sr.ReadLine());
            }
        }

        [Fact]
        public void ThirdQuaterTest()
        {
            ////Act
            Circle inFirstQuater = new Circle { Center = new Point { X = 5, Y = 5 }, Radius = 3 };
            Circle inSecondQuater = new Circle() { Center = new Point { X = -5, Y = 5 }, Radius = 2 };
            Circle inThirdQuaterTrully = new Circle() { Center = new Point { X = -5, Y = -5 }, Radius = 4 };
            Circle inThirdQuaterFalsly = new Circle() { Center = new Point { X = -5, Y = -5 }, Radius = 6 };
            Circle inFourthQuater = new Circle() { Center = new Point { X = 5, Y = -5 }, Radius = 3 };
            ////Assert
            Assert.False(inFirstQuater.InThirdQuater());
            Assert.False(inSecondQuater.InThirdQuater());
            Assert.True(inThirdQuaterTrully.InThirdQuater());
            Assert.False(inThirdQuaterFalsly.InThirdQuater());
            Assert.False(inFourthQuater.InThirdQuater());
        }
    }
}
