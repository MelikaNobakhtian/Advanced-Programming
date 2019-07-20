using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class HourHand : Hand
    {
        public HourHand(Line hand, double length, double thickness, Brush color)
            : base(hand, length, thickness, color) { }

        public override void SetDegree()
        {
            DateTime now = DateTime.Now;
            Degree = (now.Hour % 12 + now.Minute / 60F) * 30 * Math.PI / 180;
        }
    }
}