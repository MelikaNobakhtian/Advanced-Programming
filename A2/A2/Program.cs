using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Append(ref int[] append, int n)
        {
            Array.Resize(ref append, append.Length + 1);
            append[append.Length - 1] = n;
        }

        public static void AbsArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);
        }

        public static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        public static void Square(ref int num)
        {
            num *= num;
        }

        public static void AssignPi(out double pi)
        {
            pi = Math.PI;
        }

        public static void Sum(out int sum, params int[] numbers)
        {
            sum = 0;
            foreach (int num in numbers)
                sum += num;
        }

        public static void ArraySwap(int[] first, int[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                first[i] = first[i] + second[i];
                second[i] = first[i] - second[i];
                first[i] = first[i] - second[i];
            }
        }

        public static void ArraySwap(ref int[] first, ref int[] second)
        {
            int a = first.Length;
            int b = second.Length;
            if (a < b)
            {
                Array.Resize(ref first, b);
                for(int i = 0; i < a; i++)
                {
                    first[i] = first[i] + second[i];
                    second[i] = first[i] - second[i];
                    first[i] = first[i] - second[i];
                }

                for(int i = a; i < b; i++)
                {
                    first[i] = second[i];
                }

                Array.Resize(ref second, a);
            }
            else
            {
                Array.Resize(ref second, a);
                for (int i = 0; i < b; i++)
                {
                    first[i] = first[i] + second[i];
                    second[i] = first[i] - second[i];
                    first[i] = first[i] - second[i];
                }

                for (int i = b; i < a; i++)
                {
                    second[i]=first[i];
                }

                Array.Resize(ref first, b);

            }

        }
    }
}
