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
    public class FunctionTests
    {

        [TestMethod()]
        public void ParseFunctionTest()
        {
            Function firstFunction=new Function("x^2-3x+1");
            Function secondFunction=new Function("3-x^3+4x");
            Function thirdFunction=new Function("sinx");
            Func<double, double> firstFunc = firstFunction.ParsedFunc;
            Func<double, double> secondFunc = secondFunction.ParsedFunc;
            Func<double, double> thirdFunc = thirdFunction.ParsedFunc;
            Assert.AreEqual(5,firstFunc(4));
            Assert.AreEqual(-12,secondFunc(3));
            Assert.AreEqual(0,thirdFunc(0));
        }

        [TestMethod()]
        public void FactorialTest()
        {
            Assert.AreEqual(24,Function.Factorial(4));
            Assert.AreEqual(120,Function.Factorial(5));
        }

        [TestMethod()]
        public void EquationFuncTest()
        {
            string[] equations = new[] {"2x-3y=9","x+8y=12"};
            Equation equation=new Equation(equations);
            Func<double, double> firstEquationFunc = Function.EquationFunc(equation, 0);
            Func<double, double> secondEquationFunc = Function.EquationFunc(equation, 1);
            Assert.AreEqual(-1,firstEquationFunc(3));
            Assert.AreEqual(1,secondEquationFunc(4));
            Assert.AreEqual(-5,firstEquationFunc(-3));
            Assert.AreEqual(2,secondEquationFunc(-4));
        }
    }
}