using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace P1
{
    internal class CoordinatePlane
    {
        private int MinX { get; set; }
        private int MaxX { get; set; }
        private int MinY { get; set; }
        private int MaxY { get; set; }
        private List<Func<double, double>> Functions { get; set; }
        private List<Brush> FunctionColor { get; set; }
        public static double SizeX { get; set; }
        public static double SizeY { get; set; }
        private int OffsetX { get; set; }
        private int OffsetY { get; set; }
        private int Unit { get; set; }
        public Brush GridColor { get; set; }
        public Canvas Plane { get; set; }
        private Point PreviousPoint { get; set; }

        public CoordinatePlane(Canvas canvas, int minx, int miny, int maxx, int maxy)
        {
            Plane = canvas;
            MinX = minx;
            MaxX = maxx;
            MaxY = maxy;
            MinY = miny;
            Functions = new List<Func<double, double>>();
            FunctionColor = new List<Brush>();
            Plane.AllowDrop = true;
            Plane.PreviewMouseMove += Canvas_Move;
            Plane.MouseWheel += Plane_MouseWheel;

        }

        private void Plane_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            SizeX += e.Delta / 20;
            SizeY += e.Delta / 20;
            ClearScreen();
            Plane.Background = Brushes.White;
            SetProperty();
            DrawPlane();
            for (int i = 0; i < Functions.Count; i++)
            {
                DrawFunction(Functions[i], FunctionColor[i]);
            }

        }

        public void SetProperty()
        {
            Unit = SizeX / (MaxX - MinX) < SizeY / (MaxY - MinY)
                ? (int)(SizeX / (MaxX - MinX))
                : (int)(SizeY / (MaxY - MinY));
            Plane.Width = Unit * (MaxX - MinX) + 17;
            Plane.Height = Unit * (MaxY - MinY) + 15;
            SetOffset();
        }

        private void Canvas_Move(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point CurrentPoint = e.GetPosition(Plane);
                if (CurrentPoint != PreviousPoint)
                {
                    if (CurrentPoint.X != PreviousPoint.X)
                    {
                        var diffX = CurrentPoint.X - PreviousPoint.X;
                        DragAndDrop_DrawX(-diffX / 30);
                    }
                    else
                    {
                        var diffY = CurrentPoint.Y - PreviousPoint.Y;
                        DragAndDrop_DrawY(diffY / 5);
                    }
                }

            }
            else
            {
                PreviousPoint = e.GetPosition(Plane);
            }
        }

        private void DragAndDrop_DrawX(double diff)
        {
            MinX = MinX + (int)diff;
            MaxX = MaxX + (int)diff;
            ClearScreen();
            Plane.Background = Brushes.White;
            SetProperty();
            DrawPlane();
            for (int i = 0; i < Functions.Count; i++)
            {
                DrawFunction(Functions[i], FunctionColor[i]);
            }
        }

        private void DragAndDrop_DrawY(double diff)
        {
            MinY = MinY + (int)diff;
            MaxY = MaxY + (int)diff;
            ClearScreen();
            Plane.Background = Brushes.White;
            SetProperty();
            DrawPlane();
            for (int i = 0; i < Functions.Count; i++)
            {
                DrawFunction(Functions[i], FunctionColor[i]);
            }
        }
        public void SetOffset()
        {
            if (MaxX >= 0 && MinX <= 0)
            {
                for (var i = 0; i <= MaxX - MinX; i++)
                    if (MinX + i == 0)
                        OffsetY = i;
            }
            else
            {
                OffsetY = -1;
            }

            if (MinY <= 0 && MaxY >= 0)
            {
                for (var i = 0; i <= MaxY - MinY; i++)
                    if (MinY + i == 0)
                        OffsetX = i;
            }
            else
            {
                OffsetX = -1;
            }
        }

        public void ClearScreen()
        {
            Plane.Children.Clear();
            Plane.Background = GridColor;
        }

        public void DrawPlane()
        {
            for (int i = 0, j = MinX; i <= Plane.Width && j <= MaxX; i += Unit, j++)
            {
                var axiom = new Line();
                var numbers = new TextBlock();
                DrawLine(axiom, i, i, 0, Plane.Height);
                Canvas.SetTop(numbers, (-OffsetX + MaxY - MinY + 0.3) * Unit);
                Canvas.SetLeft(numbers, i + 2);
                numbers.Text = $"{j}";
                axiom.Stroke = Brushes.Chartreuse;
                axiom.StrokeThickness = 1;
                if (i / Unit == OffsetY) axiom.Stroke = Brushes.DeepPink;
                Plane.Children.Add(axiom);
                if (OffsetX != -1)
                    Plane.Children.Add(numbers);
            }

            for (int i = 0, j = MaxY; i <= Plane.Height && j >= MinY; i += Unit, j--)
            {
                var axiom = new Line();
                var numbers = new TextBlock();
                DrawLine(axiom, 0, Plane.Width, i, i);

                Canvas.SetTop(numbers, i);
                Canvas.SetLeft(numbers, (OffsetY + 0.5) * Unit);

                if (j != 0)
                    numbers.Text = $"{j}";
                if (OffsetY != -1)
                    Plane.Children.Add(numbers);
                axiom.Stroke = Brushes.Chartreuse;
                if (OffsetX == MaxY - MinY - (i / Unit))
                    axiom.Stroke = Brushes.DeepPink;
                axiom.StrokeThickness = 1;
                Plane.Children.Add(axiom);
            }
        }

        public void DrawFunction(Func<double, double> function, Brush color)
        {
            if (!Functions.Contains(function))
            {
                Functions.Add(function);
                FunctionColor.Add(color);
            }

            double previousX = 0;
            double previousY = 0;
            for (double i = MinX; i <= MaxX; i += 0.01)
            {
                var result = function(i);
                if (result >= MinY && result <= MaxY)
                {
                    previousX = (i - MinX) * Unit;
                    previousY = (MaxY - function(i)) * Unit;
                    break;
                }
            }

            for (var i = MinX + 0.01; i <= MaxX; i += 0.01)
            {
                var currentX = (i - MinX) * Unit;
                var currentY = (MaxY - function(i)) * Unit;
                if (function(i) < MinY || function(i) > MaxY)
                    continue;
                var draw = new Line();
                DrawLine(draw, previousX, currentX, previousY, currentY);
                draw.Stroke = color;
                draw.StrokeThickness = 3;
                Plane.Children.Add(draw);
                previousX = currentX;
                previousY = currentY;
            }
        }

        public void DrawLine(Line line, double x1, double x2, double y1, double y2)
        {
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
        }
    }
}