using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _equations;
        CoordinatePlane _screen;
        private CoordinatePlane _taylorCoordinatePlane;
        public MainWindow()
        {
            InitializeComponent();
            MinuteHand minuteHand = new MinuteHand(Minute, 30, 2, Brushes.DarkSalmon);
            HourHand hourHand = new HourHand(hour, 20, 3, Brushes.DeepPink);
            SecondHand secondHand = new SecondHand(Second, 30, 1, Brushes.DodgerBlue);
            Ticks ticks = new Ticks(Brushes.IndianRed, 10, 3, test);
            Face face = new Face(50, Brushes.Lavender, m);
            AnalogClock clock = new AnalogClock(50, 50, minuteHand, secondHand, hourHand, ticks, face);
            Thread start = new Thread(() => StartAnalogClock(clock));
            start.Start();
        }


        private void StartAnalogClock(AnalogClock clock)
        {
            while (true)
            {
                this.Dispatcher.BeginInvoke(new Action(clock.StartClock));
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoordinatePlane.SizeX = drawplane.ActualWidth;
            CoordinatePlane.SizeY = drawplane.ActualHeight;
            CoordinatePlane plane = new CoordinatePlane(Myplane, int.Parse(MinX.Text), int.Parse(Miny.Text), int.Parse(MaxX.Text), int.Parse(MaxY.Text));
            Myplane.Background = Brushes.White;
            plane.SetProperty();
            plane.DrawPlane();
            Function function = new Function(DrawFunction.Text);
            plane.DrawFunction(function.ParsedFunc, Brushes.Black);
            _screen = plane;
            _screen.GridColor = main.Background;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _screen.ClearScreen();

        }

        private void Equation_TextChanged(object sender, TextChangedEventArgs e)
        {
            _equations = equation.Text;
        }

        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            char[] separator = new[] { ',', '\n' };
            var equ = equation.Text.Split(separator);
            Equation ourEquations = new Equation(equ);
            if (equ.Length == 2)
            {
                CoordinatePlane.SizeX = drawequplane.ActualWidth;
                CoordinatePlane.SizeY = drawequplane.ActualHeight;
                var first = Function.EquationFunc(ourEquations, 0);
                var second = Function.EquationFunc(ourEquations, 1);
                ourEquations.Results();
                CoordinatePlane plane = new CoordinatePlane(equplane, (int)ourEquations.MyResult[0, 0] - 3, (int)ourEquations.MyResult[1, 0] - 3, (int)ourEquations.MyResult[0, 0] + 3, (int)ourEquations.MyResult[1, 0] + 3);
                equplane.Background = Brushes.White;
                plane.SetProperty();
                plane.DrawPlane();
                plane.DrawFunction(first, Brushes.Tomato);
                plane.DrawFunction(second, Brushes.DarkSlateBlue);
                _screen = plane;
                _screen.GridColor = main.Background;
            }
            string myresult = ourEquations.Results();
            Result.Text = myresult;

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (equation.Text.Split(',').Length == 2)
                _screen.ClearScreen();
            Result.Text = String.Empty;
            equation.Text = String.Empty;

        }

        private void DrawTaylor_Click(object sender, RoutedEventArgs e)
        {
            CoordinatePlane.SizeX = taylorgrid.ActualWidth;
            CoordinatePlane.SizeY = taylorgrid.ActualHeight;
            Function sinFunction = new Function("sinx");
            Func<double, double> series =
                TaylorSeries.MakeTaylorSeries(int.Parse(Number.Text), double.Parse(Point.Text), 1, 0);
            var minspan = TaylorSeries.DetermineSinSpanMin(sinFunction.ParsedFunc, series, int.Parse(Point.Text));
            var maxspan = TaylorSeries.DetermineSinSpanMax(sinFunction.ParsedFunc, series, int.Parse(Point.Text));
            var diff = maxspan - minspan;
            CoordinatePlane taylor = new CoordinatePlane(TaylorPlane, minspan - diff / 2, -2, maxspan + diff / 2, 2);
            taylor.SetProperty();
            _taylorCoordinatePlane = taylor;
            taylor.DrawPlane();
            taylor.DrawFunction(sinFunction.ParsedFunc, Brushes.Black);
            TaylorPlane.Background = Brushes.White;
            taylor.DrawFunction(series, Brushes.PaleVioletRed);

        }

        private void ClearTaylor_Click(object sender, RoutedEventArgs e)
        {
            _taylorCoordinatePlane.ClearScreen();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.PrintVisual(drawplane, "Print Digram");
        }
    }
}
