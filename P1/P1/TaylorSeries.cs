using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    static public class TaylorSeries
    {
        static public Func<double, double> DerivativeSection(int n)
        {
            switch (n % 4)
            {
                case 0:
                    return (double d) => Math.Sin(d);
                case 1:
                    return (double d) => Math.Cos(d);
                case 2:
                    return (double d) => -Math.Sin(d);
                case 3:
                    return (double d) => -Math.Cos(d);
            }

            return (double d) => 0;
        }

        static public Func<double, double> MakeExpression(int n, double point)
        {
            var number = Function.Factorial(n);
            var derivative = DerivativeSection(n);
            Func<double, double> first = (double d) => (derivative(point) / number) * Math.Pow(d - point, n);
            return (double d) => first(d);
        }



        static public Func<double, double> MakeTaylorSeries(int n, double point, int i, int j)
        {
            if (DerivativeSection(j)(point) == 0)
            {
                i--;
            }
            if (i <= n)
                return (double d) => MakeTaylorSeries(n, point, i + 1, j + 1)(d) + MakeExpression(j, point)(d);
            else
            {
                return (d) => 0;
            }
        }

        static public int DetermineSinSpanMin(Func<double, double> sinFunc, Func<double, double> taylorFunc, int point)
        {
            for (int i = point; ; i -= 1)
            {
                if (Math.Abs(taylorFunc(i) - sinFunc(i)) > 0.01)
                    return i;

            }
        }

        static public int DetermineSinSpanMax(Func<double, double> sinFunc, Func<double, double> taylorFunc, int point)
        {
            for (int i = point; ; i += 1)
            {
                if (Math.Abs(taylorFunc(i) - sinFunc(i)) > 0.01)
                    return i;

            }
        }

    }
}
