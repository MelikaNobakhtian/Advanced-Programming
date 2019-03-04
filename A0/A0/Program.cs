using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0
{
   public class Program
    {
        static void Main(string[] args)
        {
        }
        public static double Sqrt(long a)
        {
            return Math.Sqrt(a);
        }
        public static long Square(long a)
        {
            return a * a;
        }
        public static long Product(long a, long b)

        {
            return a * b;

        }
        public static long Add(long a,long b)
        {
            return a + b;
        }
        public static long Negate(long a)
        {
            return -a;
        }
        public static long Subtract(long a,long b)
        {
            return a - b;
        }
        public static long Factoriel( long a)
        {
            long factoriel = 1;
            for (long i = a; i > 0; i--)
                factoriel *= i;
            return factoriel;
        }
    }
}
