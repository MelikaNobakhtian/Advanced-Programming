using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class MinuteHand : Hand
    {

        public MinuteHand(Line hand, double length, double thickness, Brush color)
            : base(hand, length, thickness, color) { }

        public override void SetDegree()
        {
            DateTime now = DateTime.Now;
            Degree = (now.Minute) * 6 * (Math.PI) / 180;
        }


    }
}