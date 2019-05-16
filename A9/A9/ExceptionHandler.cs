using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static void ThrowIfOdd(int n)
        {
            if (n % 2 == 1)
                throw new InvalidDataException();
            return;

        }

        public void NestedMethods()
        {
            MethodA();
            Console.WriteLine("Complete NestedMethods");
        }

        private void MethodA()
        {
            MethodB();
            Console.WriteLine("Complete MethodA");
        }

        private void MethodB()
        {
            MethodC();
            Console.WriteLine("Complete MethodB");
        }

        private void MethodC()
        {
            MethodD();
            Console.WriteLine("Complete MethodC");
        }

        private void MethodD()
        {
            try
            {
                char c = Input[int.Parse(Input)];
                Console.WriteLine("Complete MethodD");
            }

            catch
            {
                throw new NotImplementedException();
            }
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
                string[] lines = File.ReadAllLines($"{Input}.txt");
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
            try
            {
                FinallyBlockStringOut = "InTryBlock::";
                int length = keyword.Length;
                if (keyword == "beautiful")
                    FinallyBlockStringOut = $"InTryBlock:{keyword}:{keyword.Length}:DoneWriting:";
            }

            catch (NullReferenceException nre)
            {

                FinallyBlockStringOut += $"{nre.Message}:";
                if (!DoNotThrow)
                    throw;
            }

            finally
            {
                if (keyword == "beautiful" || DoNotThrow)
                    FinallyBlockStringOut += $"InFinallyBlock:EndOfMethod";
                else
                    FinallyBlockStringOut += "InFinallyBlock";


            }
        }
    }
}
