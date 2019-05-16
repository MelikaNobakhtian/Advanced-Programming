using System;
using A9;
using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A9Tests
{
    [TestClass]
    public class MultipleExceptionTests
    {
        #region MultiException
        [TestMethod]
        public void TestNoMultiException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "0", false);

            eh.MultiExceptionMethod();

            Assert.AreEqual(null, eh.ErrorMsg);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void TestThrowMultiNoException1()
        {
            ExceptionHandler eh = new ExceptionHandler(
                int.MaxValue.ToString(), false);

            eh.MultiExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(OutOfMemoryException)}",
                eh.ErrorMsg);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestThrowMultiNoException2()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "1", false);

            eh.MultiExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(OutOfMemoryException)}",
                eh.ErrorMsg);
        }

        [TestMethod]
        public void TestCatchMultiNoException1()
        {
            ExceptionHandler eh = new ExceptionHandler(
                int.MaxValue.ToString(), false, true);

            eh.MultiExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(OutOfMemoryException)}",
                eh.ErrorMsg);
        }

        [TestMethod]
        public void TestCatchMultiNoException2()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "1", false, true);

            eh.MultiExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(IndexOutOfRangeException)}",
                eh.ErrorMsg);
        }
        #endregion

    }
}