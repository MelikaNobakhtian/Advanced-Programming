using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A14
{
     public class Program
    {
        public static void Main(string[] args)
        {
            RunCalculator(() => Console.ReadKey().KeyChar, Console.Clear);
        }

        public static Calculator RunCalculator(Func<char> GetKey, Action clearScreen)
        {
            Calculator calc = new Calculator(clearScreen);
            while (true)
            {
                calc.PrintDisplay();
                char key = GetKey();
                switch (key)
                {
                    case '.':
                        calc.EnterPoint();
                        break;
                    case '0':
                        calc.EnterZeroDigit();
                        break;
                    case '=':
                    case (char)ConsoleKey.Enter:
                        calc.EnterEqual();
                        break;
                    case (char)ConsoleKey.Escape:
                        calc.Clear();
                        break;
                    case var c when c != '0' && char.IsDigit(c):
                        calc.EnterNonZeroDigit(c);
                        break;
                    case var c when Calculator.Operators.ContainsKey(c):
                        calc.EnterOperator(c);
                        break;
                    case 'q':
                        return calc;
                }
            }
        }
        }
}
