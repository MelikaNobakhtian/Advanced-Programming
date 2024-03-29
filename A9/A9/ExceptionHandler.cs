﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;
        public string FinallyBlockStringOut { get; set; }

        public string Input
        {
            get
            {
                try
                {
                    if (_Input != null)
                        return _Input;
                    else
                    {
                        int i = _Input.Length;
                    }

                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    if (value != null)
                        _Input = value;
                    else
                    {
                        int j = value.Length;
                    }
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow = false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    input = null;
                    int len = input.Length;
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public static void ThrowIfOdd(int num)
        {
            if (num % 2 == 1)
                throw new InvalidDataException();
            return;

        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void NestedMethods()
        {
            MethodA();
            Console.WriteLine("Complete NestedMethods");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodA()
        {
            MethodB();
            Console.WriteLine("Complete MethodA");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodB()
        {
            MethodC();
            Console.WriteLine("Complete MethodB");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodC()
        {
            MethodD();
            Console.WriteLine("Complete MethodC");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodD()
        {

            throw new NotImplementedException();

        }

        public void OverflowExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                checked
                { n++; }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch (FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                string[] lines = File.ReadAllLines($@"..\..\..\{Input}.txt");
            }

            catch (FileNotFoundException ffe)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ffe.GetType()}";
            }

        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                string s = "a";
                char c = s[int.Parse(Input)];
            }

            catch (IndexOutOfRangeException ior)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ior.GetType()}";
            }

        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int[] a = new int[int.Parse(Input)];
            }

            catch (OutOfMemoryException ome)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ome.GetType()}";
            }

        }

        public void MultiExceptionMethod()
        {
            try
            {
                string[] n = new string[int.Parse(Input)];
                char c = Input[int.Parse(Input)];
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FinallyBlockMethod(string keyword)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (keyword == "beautiful")
                    sb.Append($"InTryBlock:{keyword}:{keyword.Length}:DoneWriting:");
                else
                {
                    sb.Append("InTryBlock::");
                    int length = keyword.Length;
                }

            }


            catch (NullReferenceException nre)
            {
                sb.Append($"{nre.Message}:");
                if (!DoNotThrow)
                    throw;
            }

            finally
            {
                sb.Append("InFinallyBlock");
                FinallyBlockStringOut = sb.ToString();
            }
            if (keyword == "beautiful" || DoNotThrow)
                FinallyBlockStringOut += ":EndOfMethod";
        }
    }
}
