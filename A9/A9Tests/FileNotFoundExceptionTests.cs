using System.IO;
using A9;
using ExceptionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A9Tests
{

    [TestClass]
    public class FileNotFoundExceptionTests
    {
        #region FileNotFoundException
        [TestMethod]
        public void TestNoFileNotFoundException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                "10", false);
            eh.FileNotFoundExceptionMethod();
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestThrowFileNotFoundException()
        {
            ExceptionHandler eh = new ExceptionHandler(int.MaxValue.ToString(), false);
            eh.FileNotFoundExceptionMethod();
        }

        [TestMethod]
        public void TestCatchFileNotFoundException()
        {
            ExceptionHandler eh = new ExceptionHandler(
                int.MaxValue.ToString(), false, true);
            eh.FileNotFoundExceptionMethod();

            Assert.AreEqual(
                $"Caught exception {typeof(FileNotFoundException)}",
                eh.ErrorMsg);
        }
        #endregion
    }
}