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
    public class SquareMatrixTests
    {

        [TestMethod()]
        public void CreateSmallerMatrixTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {1, 2, 3},
                new Vector<double>(3) {4, 5, 6},
                new Vector<double>(3) {7, 8, 9}
            };

            var smaller = matrix.CreateSmallerMatrix(matrix, 1, 1);
            var expected=new SquareMatrix<double>(2)
            {
                new Vector<double>(2){1,3},
                new Vector<double>(2){7,9}
            };
            Assert.AreEqual(expected,smaller);
        }

        [TestMethod()]
        public void SignOfElementTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {1, 2, 3},
                new Vector<double>(3) {4, 5, 6},
                new Vector<double>(3) {7, 8, 9}
            };
            var actual=matrix.SignOfElement(1, 2);
            Assert.AreEqual(-1,actual);
        }

        [TestMethod()]
        public void DeterminantTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {1, 2, 3},
                new Vector<double>(3) {3, 2, 1},
                new Vector<double>(3) {2, 1, 3}
            };
            Assert.AreEqual(-12,matrix.Determinant(matrix));

        }

        [TestMethod()]
        public void MatchingMatrixTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {2, 4, 9},
                new Vector<double>(3) {-1, 0, -7},
                new Vector<double>(3) {3, 6, 10}
            };

            var matching = matrix.MatchingMatrix();
            var expected = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {42, -11, -6},
                new Vector<double>(3) {14, -7, 0},
                new Vector<double>(3) {-28, 5, 4}
            };
            Assert.AreEqual(expected,matching);
        }

        [TestMethod()]
        public void TranslatedMatrixTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {2, 4, 9},
                new Vector<double>(3) {-1, 0, -7},
                new Vector<double>(3) {3, 6, 10}
            };
            var actual = matrix.TranslatedMatrix();
            var expected= new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {2, -1, 3},
                new Vector<double>(3) {4, 0, 6},
                new Vector<double>(3) {9, -7, 10}
            };
            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void InverseMatrixTest()
        {
            SquareMatrix<double> matrix = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {3, 0, 2},
                new Vector<double>(3) {2, 0, -2},
                new Vector<double>(3) {0, 1, 1}
            };
            var actual = matrix.InverseMatrix();
            var expected= new SquareMatrix<double>(3)
            {
                new Vector<double>(3) {0.2, 0.2, 0},
                new Vector<double>(3) {-0.2, 0.3, 1},
                new Vector<double>(3) {0.2, -0.3, 0}
            };
            Assert.AreEqual(actual,expected);
        }
    }
}