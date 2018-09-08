using System;
using System.Collections.Generic;
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
    }
}
