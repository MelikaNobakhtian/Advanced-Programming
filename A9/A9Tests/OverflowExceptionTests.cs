using System;
using A9;
using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A9Tests
{

    [TestClass]
    public class OverflowExceptionTests
    {
        #region OverflowException
        [TestMethod]
        public void TestNoOverflowException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "10", false);
            eh.OverflowExceptionMethod();
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestThrowOverflowException()
        {
            ExceptionHandler eh = new ExceptionHandler(int.MaxValue.ToString(), false);
            eh.OverflowExceptionMethod();
        }

        [TestMethod]
        public void TestCatchOverflowException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                int.MaxValue.ToString(), false, true);
            eh.OverflowExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(OverflowException)}",
                eh.ErrorMsg);
        }
        #endregion
    }
}