using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.MVVM;

namespace Task2Tests
{
    [TestClass]
    public class Hexagone_Tests
    {
        [TestMethod]
        public void Test_PointsProperty()
        {
            Hexagone hexagone = new Hexagone();
            PointCollection points = new PointCollection();
            points.Add(new Point(67, 89));
            points.Add(new Point(67, 45));
            points.Add(new Point(56, 23));
            points.Add(new Point(10, 9));
            points.Add(new Point(100, 145));
            points.Add(new Point(23, 76));
            hexagone.Points = points;
            Assert.AreEqual(hexagone.Points, points);
        }

        [TestMethod]
        public void Test_HexagoneColorProperty()
        {
            Hexagone hexagone = new Hexagone();
            hexagone.HexagoneColor = Colors.Red;
            Assert.AreEqual(hexagone.HexagoneColor, Colors.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_PointsPropertyException()
        {
            Hexagone hexagone = new Hexagone();
            PointCollection points = new PointCollection();

            //Too many points for hexagone (7)
            points.Add(new Point(67, 89));
            points.Add(new Point(67, 45));
            points.Add(new Point(56, 23));
            points.Add(new Point(10, 9));
            points.Add(new Point(100, 145));
            points.Add(new Point(23, 76));
            points.Add(new Point(23, 76));
            hexagone.Points = points;
        }
    }
}
