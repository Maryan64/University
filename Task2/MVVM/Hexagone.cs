using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2.MVVM
{
    [Serializable]
    public class Hexagone
    {
        private PointCollection points;
        public PointCollection Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value.Count != 6)
                {
                    throw new ArgumentException("Count of points can't be greater than 6");
                }

                points = value;
            }
        }
        public Color HexagoneColor { get; set; }

        public Hexagone()
        {
        }

        public Hexagone(Polygon figure)
        {
            Points = figure.Points;
            HexagoneColor = (figure.Fill as SolidColorBrush).Color;
        }
    }
}
