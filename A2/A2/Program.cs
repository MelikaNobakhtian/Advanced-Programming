using System;

namespace A2
{
    public class Program
    {
        private static void Main(string[] args)
        {
        }

        public static void Append(ref int[] append, int n)
        {
            Array.Resize(ref append, append.Length + 1);
            append[append.Length - 1] = n;
        }

        public static void AbsArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);
        }

        public static void Swap(ref int a, ref int b)
        {
            var c = a;
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
            foreach (var num in numbers)
                sum += num;
        }

        public static void ArraySwap(int[] first, int[] second)
        {
            for (var i = 0; i < first.Length; i++)
            {
                first[i] = first[i] + second[i];
                second[i] = first[i] - second[i];
                first[i] = first[i] - second[i];
            }
        }

        public static void ArraySwap(ref int[] first, ref int[] second)
        {
            var thirdArray = first;
            first = second;
            second = thirdArray;
        }
    }
}