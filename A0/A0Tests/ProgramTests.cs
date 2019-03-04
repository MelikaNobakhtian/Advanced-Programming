using Microsoft.VisualStudio.TestTools.UnitTesting;
using A0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void SqrtTest()
        {
            double expectedresult = 2;
            double functionresult = Program.Sqrt(4);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void SquareTest()
        {
            long expectedresult = 25;
            long functionresult = Program.Square(5);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void ProductTest()
        {
            long expectedresult = 6;
            long functionresult = Program.Product(2, 3);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void AddTest()
        {
            long expectedresult = 4;
            long functionresult = Program.Add(1, 3);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void NegateTest()
        {
            long expectedresult = 4;
            long functionresult = Program.Negate(-4);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            long expectedresult = 4;
            long functionresult = Program.Subtract(7, 3);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void FactorielTest()
        {
            long expectedresult = 6;
            long functionresult = Program.Factoriel( 3);
            Assert.AreEqual(expectedresult, functionresult);
        }
    }
}