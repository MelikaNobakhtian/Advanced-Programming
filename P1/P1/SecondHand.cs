using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class SecondHand : Hand
    {
        public SecondHand(Line hand, double length, double thickness, Brush color)
            : base(hand, length, thickness, color) { }

        public override void SetDegree()
        {
            DateTime now = DateTime.Now;
            Degree = (now.Second) * 6 * Math.PI / 180;
        }
    }
}