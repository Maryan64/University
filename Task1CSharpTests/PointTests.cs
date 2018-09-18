using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xunit;
using Task1CSharp.Classes;
namespace Task1CSharpTests
{
    public class PointTests
    {
        private Point point;
        private int X;
        private int Y;
        private const string READ = "../../../pointRead.txt";
        public PointTests()
        {
            X = 20;
            Y = 6;
            point = new Point() { X = this.X, Y = this.Y };
        }
        [Fact]
        public void InputCorrect()
        {
            //Act
            Point p;
            using (StreamReader sr = new StreamReader(READ, Encoding.Default))
            {
                p = new Point();
                string[] inputCortegge = sr.ReadLine().Split(' ');
                p.X = double.Parse(inputCortegge[0]);
                p.Y = double.Parse(inputCortegge[1]);
            }
            string real = p.X.ToString() + p.Y.ToString();
            string expected = "105";
            //Assert
            Assert.Equal(real, expected);
        }
    }
}
