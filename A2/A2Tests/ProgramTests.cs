using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AppendTest()
        {
            int[] test = new int[] { 1, 2, 3 };
            Program.Append(ref test, 5);
            int[] expected = new int[] { 1, 2, 3, 5 };
            CollectionAssert.AreEqual(test, expected);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] test = new int[] { -6, -9, 4, 5 };
            Program.AbsArray(test);
            int[] expected = new int[] { 6, 9, 4, 5 };
            CollectionAssert.AreEqual(test, expected);
            
        }

        [TestMethod()]
        public void SwapTest()
        {
            int a = 5, b = 6;
            Program.Swap(ref a, ref b);
            Assert.AreEqual(a, 6);
            Assert.AreEqual(b, 5);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int num = 2;
            Program.Square(ref num);
            Assert.AreEqual(num, 4);
        }

        [TestMethod()]
        public void AssignPiTest()
        {
            double pi;
            Program.AssignPi(out pi);
            double expected = Math.PI;
            Assert.AreEqual(expected, pi);
        }

        [TestMethod()]
        public void SumTest()
        {
            int sum;
            Program.Sum(out sum, 4, 89, 2, -7);
            Assert.AreEqual(sum, 88);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] test1 = new int[] { 1, 2, 3 };
            int[] test2 = new int[] { 4, 5, 6 };
            Program.ArraySwap(test1, test2);
            int[] expected1 = new int[] { 4, 5, 6 };
            int[] expected2 = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(test1, expected1);
            CollectionAssert.AreEqual(test2, expected2);

        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            int[] test1 = new int[] { 1, 3 };
            int[] test2 = new int[] { 4, 5, 9, 10 };
            Program.ArraySwap(ref test2, ref test1);
            int[] expected1 = new int[] { 4, 5, 9, 10 };
            int[] expected2 = new int[] { 1, 3 };
            CollectionAssert.AreEqual(test1, expected1);
            CollectionAssert.AreEqual(test2, expected2);
        }
    }
}