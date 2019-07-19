using System;

namespace P1
{
    public class Function
    {
        public string Functions { get; set; }
        public Func<double, double> ParsedFunc { get; set; }

        public Function(string function)
        {
            Functions = function;
            ParsedFunc = ParseFunction(Functions);
        }

        public Func<double, double> ParseFunction(string functions)
        {
            if (functions.Contains("sin"))
            {
                return SinFunc(functions);
            }

            if (functions.Contains("cos"))
            {
                return CosFunc(functions);
            }

            if (functions.Contains("+"))
            {
                var index = functions.IndexOf("+");
                return PlusFunc(index, functions);
            }

            if (functions.Contains("-"))
            {
                var index = functions.IndexOf("-");
                return MinusFunc(index, functions);
            }

            for (var i = 0; i < functions.Length; i++)
            {
                if (functions[i] == '*')
                    return d => ParseFunction(functions.Substring(0, i))(d) *
                                ParseFunction(functions.Substring(i + 1))(d);
                if (char.IsDigit(functions[i]) && i != functions.Length - 1 && char.IsLetter(functions[i + 1]))
                    return d => double.Parse(functions.Substring(0, i + 1)) *
                                ParseFunction(functions.Substring(i + 1))(d);
            }

            for (var i = 0; i < functions.Length; i++)
                if (functions[i] == '^')
                    return d => Math.Pow(d, double.Parse(functions[i + 1].ToString()));

            for (var i = 0; i < functions.Length; i++)
                if (char.IsDigit(functions[i]))
                    return d => double.Parse(functions);
                else if (char.IsLetter(functions[i]))
                    return d => d;

            return d => 0;
        }

        private Func<double, double> CosFunc(string functions)
        {
            double outCoefficient = 1;
            var indexC = functions.IndexOf('c');
            if (indexC != 0 && !Char.IsLetter(functions[1]))
                outCoefficient = double.Parse(functions.Substring(0, indexC));
            else if (functions[0] == '-')
            {
                outCoefficient = -1;
            }
            var indexS = functions.IndexOf('s');
            var indexX = functions.IndexOf('x');
            double inCoefficient = 1;
            if (indexX - indexS > 1 && functions[indexX - 1] != '-')
                inCoefficient = double.Parse(functions.Substring(indexS + 1, indexX - indexS - 1));
            else if (functions[indexX - 1] == '-')
            {
                inCoefficient = -1;
            }

            return (double d) => outCoefficient * Math.Cos(inCoefficient * d);
        }

        public Func<double, double> PlusFunc(int index, string functions)
        {
            return d => ParseFunction(functions.Substring(0, index))(d) +
                        ParseFunction(functions.Substring(index + 1))(d);
        }

        public Func<double, double> MinusFunc(int index, string functions)
        {
            return d => ParseFunction(functions.Substring(0, index))(d) -
                        ParseFunction(functions.Substring(index + 1))(d);
        }

        public static int Factorial(int n)
        {
            int value = 1;
            if (n == 0)
                return value;
            for (int i = 1; i <= n; i++)
                value *= i;
            return value;
        }

        public static Func<double, double> EquationFunc(Equation equations, int n)
        {
            return (double d) =>
                (-d * equations.Coefficients[n, 0] + equations.Numbers[n, 0]) / equations.Coefficients[n, 1];
        }

        private Func<double, double> SinFunc(string functions)
        {
            double outCoefficient = 1;
            var indexS = functions.IndexOf('s');
            if (indexS != 0 && !Char.IsLetter(functions[1]))
                outCoefficient = double.Parse(functions.Substring(0, indexS));
            else if (functions[0] == '-')
            {
                outCoefficient = -1;
            }
            var indexN = functions.IndexOf('n');
            var indexX = functions.IndexOf('x');
            double inCoefficient = 1;
            if (indexX - indexN > 1 && functions[indexX - 1] != '-')
                inCoefficient = double.Parse(functions.Substring(indexN + 1, indexX - indexN - 1));
            else if (functions[indexX - 1] == '-')
            {
                inCoefficient = -1;
            }

            return (double d) => outCoefficient * Math.Sin(inCoefficient * d);
        }

    }
}