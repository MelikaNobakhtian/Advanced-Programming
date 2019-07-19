using System;
using System.Windows.Shapes;
using System.Windows.Media;

namespace P1
{
    public abstract class Hand
    {
        public double Length { get; set; }
        public Line ClockHand { get; set; }
        public double Degree { get; set; }

        public Hand(Line hand, double length, double thickness, Brush color)
        {
            ClockHand = hand;
            ClockHand.Stroke = color;
            ClockHand.StrokeThickness = thickness;
            Length = length;
        }

        public abstract void SetDegree();
        public void SetEndOfHand(double CenterX, double CenterY)
        {
            SetDegree();
            ClockHand.X2 = CenterX + Length * Math.Sin(Degree);
            ClockHand.Y2 = CenterY - Length * Math.Cos(Degree);
        }

    }
}