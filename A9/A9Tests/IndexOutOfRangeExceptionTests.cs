using System;
using A9;
using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A9Tests
{

    [TestClass]
    public class IndexOutOfRangeExceptionTests
    {
        #region IndexOutOfRangeException
        [TestMethod]
        public void TestNoIndexOutOfRangeException()
        {
            ExceptionHandler eh = new ExceptionHandler("0", false);
            eh.IndexOutOfRangeExceptionMethod();
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestThrowIndexOutOfRangeException()
        {
            ExceptionHandler eh = new ExceptionHandler("1", false);
            eh.IndexOutOfRangeExceptionMethod();
        }

        [TestMethod]
        public void TestCatchIndexOutOfRangeException()
        {
            ExceptionHandler eh = new ExceptionHandler("1", false, true);
            eh.IndexOutOfRangeExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(IndexOutOfRangeException)}",
                eh.ErrorMsg);
        }
        #endregion
    }
}