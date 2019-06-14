using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10.Tests
{
    [TestClass()]
    public class SquareMatrixTests
    {
        [TestMethod()]
        public void SquareMatrixTest()
        {
            SquareMatrix<int> m = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 10, 11, 12},
                new Vector<int>(3) { 20, 21, 22},
                new Vector<int>(3) { 30, 31, 32}
            };

            for (int i = 0; i < m.RowCount; i++)
                for (int j = 0; j < m.ColumnCount; j++)
                    Assert.AreEqual(
                        (i + 1) * 10 + j,
                        m[i, j]);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SquareMatrixCostructorExceptionTest()
        {
            List<Vector<int>> vectors = new List<Vector<int>>()
            {
                new Vector<int>(3){1,2,3},
                new Vector<int>(3){4,5,6}
            };

            var mat = new SquareMatrix<int>(vectors);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2,1},
                new Vector<int>(3) { 2, -1,1},
                new Vector<int>(3) { -1, 2,1}
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { -1, 2,1},
                new Vector<int>(3) { 2, 1,-1},
                new Vector<int>(3) { 1, 2,-1}
            };

            var m3 = m1 * m2;

            Assert.AreEqual(4, m3[0, 0], "wrong value [0, 0]");
            Assert.AreEqual(6, m3[0, 1], "wrong value [0, 1]");
            Assert.AreEqual(-2, m3[0, 2], "wrong value [0, 2]");
            Assert.AreEqual(-3, m3[1, 0], "wrong value [1, 0]");
            Assert.AreEqual(5, m3[1, 1], "wrong value [1, 1]");
            Assert.AreEqual(2, m3[1, 2], "wrong value [1, 2]");
            Assert.AreEqual(6, m3[2, 0], "wrong value [2, 0]");
            Assert.AreEqual(2, m3[2, 1], "wrong value [2, 1]");
            Assert.AreEqual(-4, m3[2, 2], "wrong value [2, 2]");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultiplyExceptionTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
                new Vector<int>(3) { -2, -1, -1}
            };

            var m3 = m1 * m2;
        }

        [TestMethod]
        public void AddTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 2},
                new Vector<int>(2) { 1, 4},
            };

            var m3 = m1 + m2;

            Assert.AreEqual(new Vector<int>(2) { 1, 4 }, m3[0]);
            Assert.AreEqual(new Vector<int>(2) { 3, 3 }, m3[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddExceptionTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 0, 2, 1},
                new Vector<int>(3) { -1, 2, 1},
                new Vector<int>(3) { 1, 2, 1},
            };

            var m3 = m1 + m2;
        }

        [TestMethod]
        public void MultiplyTestLong()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(
                 Enumerable.Repeat(new Vector<int>(Enumerable.Repeat(0, 60)), 60)
                 );

            SquareMatrix<int> m2 = new SquareMatrix<int>(
                Enumerable.Repeat(new Vector<int>(Enumerable.Repeat(1, 60)), 60)
                );

            Vector<int> result = new Vector<int>(Enumerable.Repeat(0, 60));

            var m3 = m1 * m2;
            foreach (var d in m3)
                Assert.AreEqual(d, result);

        }

        [TestMethod()]
        public void EqualsTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(3) { 1, 2},
                new Vector<int>(3) { 2, -1}
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(3) { 1, 2},
                new Vector<int>(3) { 2, -1}
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 7, 2},
                new Vector<int>(2) { 2, 6}
            };

            SquareMatrix<int> m4 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, 0, 1},
                new Vector<int>(3) { 2, 0, 1}
            };

            Assert.AreEqual(m1, m2);
            Assert.AreNotEqual(m1, m3);

            Assert.IsTrue(m1 == m2);
            Assert.IsTrue(m1 != m3);

            Assert.AreNotEqual(m3, m4);
            Assert.IsFalse(m3 == m4);
            Assert.IsTrue(m3 != m4);
        }

        [TestMethod()]
        public void IEnumerableTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
                new Vector<int>(3) { 6, 7, 8}
            };

            int idx = 0;
            foreach (var vec in m1)
                foreach (var item in vec)
                    Assert.AreEqual(idx++, item);
        }


        [TestMethod]
        public void AccessorTest()
        {
            SquareMatrix<int> m = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
                new Vector<int>(3) { 6, 7, 8}
            };

            Assert.AreEqual(new Vector<int>(3) { 0, 1, 2 }, m[0]);
            Assert.AreEqual(new Vector<int>(3) { 3, 4, 5 }, m[1]);

            for (int i = 0; i < m.RowCount; i++)
                for (int j = 0; j < m.ColumnCount; j++)
                    Assert.AreEqual(i * 3 + j, m[i, j]);
        }

        [TestMethod]
        public void MultiAddTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 1, 0},
            };

            var m = m1 + m2 + m3;

            Assert.AreEqual(m[0], new Vector<int>(2) { -1, 3 });
            Assert.AreEqual(m[1], new Vector<int>(2) { 4, 1 });
        }

        [TestMethod]
        public void MultiMultiplyTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 1, 0},
            };

            var m = (m1 * m2) * m3;

            Assert.AreEqual(m[0], new Vector<int>(2) { 2, 1 });
            Assert.AreEqual(m[1], new Vector<int>(2) { 0, -3 });
        }

        [TestMethod]
        public void MultiExpressionTest()
        {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 1, 0},
            };

            var m = ((m1 + m2) * (m3 + m1)) + (m2 + m3);

            Assert.AreEqual(m[0], new Vector<int>(2) { 5, -2 });
            Assert.AreEqual(m[1], new Vector<int>(2) { 5, 7 });
        }

        [TestMethod()]
        public void MatrixToStringTest()
        {
            SquareMatrix<int> m = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 10, 11, 12},
                new Vector<int>(3) { 20, 21, 22},
                new Vector<int>(3) { 30, 31, 32}
            };

            Assert.AreEqual("[\n[10,11,12],\n[20,21,22],\n[30,31,32]\n]", m.ToString());
        }
    }
}