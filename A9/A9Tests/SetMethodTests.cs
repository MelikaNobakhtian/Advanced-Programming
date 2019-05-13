using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using A9;

namespace ExceptionHandling.Tests
{

    [TestClass]
    public class SetMethodTests
    {
        #region SetMethodTest
        [TestMethod]
        public void TestNoSetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler("test", false);
            eh.Input = "test1";
            Assert.AreEqual(eh.Input, "test1");
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestThrowSetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler("test", false);
            eh.Input = null;
            Assert.AreEqual(eh.Input, null);
            Assert.AreEqual(eh.ErrorMsg, null);
        }

        [TestMethod]
        public void TestCatchSetMethodException()
        {
            ExceptionHandler eh = new ExceptionHandler("test", false, true);
            eh.Input = null;
            Assert.AreEqual(eh.ErrorMsg, "Caught exception in SetMethod");
        }

        #endregion
    }
}