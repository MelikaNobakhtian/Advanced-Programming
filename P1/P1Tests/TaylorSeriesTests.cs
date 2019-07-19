using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class TaylorSeriesTests
    {
        [TestMethod()]
        public void DerivativeSectionTest()
        {
            var actual1 = TaylorSeries.DerivativeSection(1);
            var actual2 = TaylorSeries.DerivativeSection(2);
            var actual3 = TaylorSeries.DerivativeSection(3);
            var actual4 = TaylorSeries.DerivativeSection(4);
            Assert.AreEqual(1,actual1(0));
            Assert.AreEqual(0,actual2(0));
            Assert.AreEqual(-1,actual3(0));
            Assert.AreEqual(0,actual4(0));

        }

        [TestMethod()]
        public void MakeExpressionTest()
        {
            Func<double, double> expected = (double x) => -Math.Pow(x, 3) / 6;
            Func<double, double> actual = TaylorSeries.MakeExpression(3, 0);
            Assert.AreEqual(actual(5),expected(5));
        }

        [TestMethod()]
        public void MakeTaylorSeriesTest()
        {
            var actual = TaylorSeries.MakeTaylorSeries(4, 1, 1, 0);
            Func<double, double> expected = (double d) => Math.Sin(1) * Math.Pow(d - 1, 0) / Function.Factorial(0)
                                                          + Math.Cos(1) * Math.Pow(d - 1, 1) / Function.Factorial(1)
                                                          - Math.Sin(1) * Math.Pow(d - 1, 2) / Function.Factorial(2)
                                                          - Math.Cos(1) * Math.Pow(d - 1, 3) / Function.Factorial(3);
            Assert.AreEqual(actual(1),expected(1));
        }

        [TestMethod()]
        public void DetermineSinSpanMinTest()
        {
            Function sinFunction = new Function("sin(x)");
            Func<double, double> series =
                TaylorSeries.MakeTaylorSeries(4, 0, 1, 0);
            var minspan = TaylorSeries.DetermineSinSpanMin(sinFunction.ParsedFunc, series, 0);
            Assert.AreEqual(-3,minspan);
        }

        [TestMethod()]
        public void DetermineSinSpanMaxTest()
        {
            Function sinFunction = new Function("sin(x)");
            Func<double, double> series =
                TaylorSeries.MakeTaylorSeries(4, 0, 1, 0);
            var maxspan = TaylorSeries.DetermineSinSpanMax(sinFunction.ParsedFunc, series, 0);
            Assert.AreEqual(3,maxspan);
        }
    }
}