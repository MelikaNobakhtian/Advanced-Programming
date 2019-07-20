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
    public class EquationTests
    {
        [TestMethod()]
        public void GetVariablesTest()
        {
            string[] equations = new[] {"4x+y-z+t=7","y+x-5t-z=-1","z-3t+x-y=6","t+x-z+3y=1"};
            Equation equation=new Equation(equations);
            List<char> expectedVariables=new List<char>(){'x','y','z','t'};
            CollectionAssert.AreEquivalent(equation.Variables,expectedVariables);
        }

        [TestMethod()]
        public void MultipleMatrixTest()
        {
            string[] equations = new[] { "4x+y-z+t=7", "y+x-5t-z=-1", "z-3t+x-y=6", "t+x-z+3y=1" };
            Equation equation = new Equation(equations);
            Assert.AreEqual(new Vector<double>(4){4,1,-1,1},equation.Coefficients[0] );
            Assert.AreEqual(new Vector<double>(4){1,1,-1,-5},equation.Coefficients[1] );
            Assert.AreEqual(new Vector<double>(4){1,-1,1,-3},equation.Coefficients[2] );
            Assert.AreEqual(new Vector<double>(4){1,3,-1,1},equation.Coefficients[3] );

        }

        [TestMethod()]
        public void SetRelationsTest()
        {
            string[] equations = new[] { "4x+y-z+t=7", "y+x-5t-z=-1", "z-3t+x-y=6", "t+x-z+3y=1" };
            string[] equations2 = new[] {"x-6y=7","2x-y=5"};
            Equation equation2=new Equation(equations2);
            Equation equation = new Equation(equations);
            var relation = equation.SetRelations(0, 1);
            var relation2 = equation2.SetRelations(0, 1);
            Assert.AreEqual(new Matrix<double>(1,5){new Vector<double>(5){4,1,1,-0.2,-7}},relation );
            Assert.AreEqual(new Matrix<double>(1,3){new Vector<double>(3){0.5,6,1.4}},relation2);
        }

        [TestMethod()]
        public void HasSameRelationTest()
        {
            string[] equation = new[] {"2x+2y+2z=-2", "2x+3y+2z=4", "x+y+z=-1"};
            Equation equations=new Equation(equation);
            var relation = equations.SetRelations(0, 2);
            string result = equations.HasSameRelation(relation);
            Assert.AreEqual(result, "No Unique Solution");
        }

        [TestMethod()]
        public void ResultsTest()
        {
            string[] equation = new[] {"7x+5y-3z=16", "3x-5y+2z=-8", "5x+3y-7z=0" };
            Equation equations=new Equation(equation);
            equations.Results();
            var expectedResults = new Matrix<double>(3,1){
                new Vector<double>(1){1},
                new Vector<double>(1){3},
                new Vector<double>(1){2}};
            var realResults= equations.MyResult;
            Assert.AreEqual(expectedResults,realResults);


        }
    }
}