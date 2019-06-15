using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            FullName f = obj as FullName;
            if (f == null)
                return false;
            return (this.FirstName == f.FirstName && this.LastName == f.LastName);
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            string[] n = expression.Split('+');
            int test;
            int sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == "")
                    throw new InvalidDataException();
                if (int.TryParse(n[i], out test))
                    sum += test;
                else
                    throw new FormatException();
            }

            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            string[] n = expression.Split('+');
            int test;
            value = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == "")
                    return false;
                if (int.TryParse(n[i], out test))
                    value += test;
                else
                    return false;

            }
            return true;
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            var pi = Math.Round(Math.PI, 7);
            int result;
            double sum = 0;
            for (int i = 0; ; i++)
            {
                sum +=(1.0/(2 * i + 1)) * Math.Pow(-1, i);
                if (Math.Round(4 * sum,7) == pi)
                {
                    result = i+1;
                    break;
                }
            }

            return result;
        }

        public static int Fibonacci(this int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}