using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Ticks
    {
        Brush Color { get; set; }
        double Length { get; set; }
        double Thickness { get; set; }
        Canvas Plane { get; set; }

        public Ticks(Brush color, double length, double thickness, Canvas plane)
        {
            Color = color;
            Length = length;
            Thickness = thickness;
            Plane = plane;
        }

        public void Set5minTicks(double radius, double CenterX, double CenterY)
        {
            for (int i = 0; i < 60; i++)
            {
                Line line = new Line();
                if (i % 5 == 0)
                {

                    line.X1 = CenterX + 10 + (float)((radius - Length) * Math.Sin(i * 6 * Math.PI / 180));
                    line.Y1 = CenterY + 25 - (float)((radius - Length) * Math.Cos(i * 6 * Math.PI / 180));
                    line.X2 = CenterX + 10 + (float)(radius * Math.Sin(i * 6 * Math.PI / 180));
                    line.Y2 = CenterY + 25 - (float)(radius * Math.Cos(i * 6 * Math.PI / 180));
                    line.StrokeThickness = Thickness;
                    line.Stroke = Color;
                    Plane.Children.Add(line);
                }
            }
        }
    }
}