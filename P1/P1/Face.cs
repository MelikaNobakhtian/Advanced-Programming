using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Face
    {
        private double Radius { get; set; }
        private Brush FaceColor { get; set; }
        private Ellipse ClockFace { get; set; }

        public Face(double radius, Brush color, Ellipse clockFace)
        {
            Radius = radius;
            FaceColor = color;
            ClockFace = clockFace;
        }

        public void SetFace()
        {
            ClockFace.Width = 2 * Radius;
            ClockFace.Height = 2 * Radius;
            ClockFace.Fill = FaceColor;
        }
    }
}
