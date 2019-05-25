using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void MatrixTest()
        {
            Matrix<int> m = new Matrix<int>(3, 4)
            {
                new Vector<int>(4) { 10, 11, 12, 13},
                new Vector<int>(4) { 20, 21, 22, 23},
                new Vector<int>(4) { 30, 31, 32, 33}
            };

            for (int i = 0; i < m.RowCount; i++)
                for (int j = 0; j < m.ColumnCount; j++)
                    Assert.AreEqual(
                        (i + 1) * 10 + j,
                        m[i, j]);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m2 = new Matrix<int>(3, 2)
            {
                new Vector<int>(2) { -1, 2},
                new Vector<int>(2) { 2, 1},
                new Vector<int>(2) { 1, 2}
            };

            var m3 = m1 * m2;

            Assert.AreEqual(4, m3[0, 0], "wrong value [0, 0]");
            Assert.AreEqual(6, m3[0, 1], "wrong value [0, 1]");
            Assert.AreEqual(-3, m3[1, 0], "wrong value [1, 0]");
            Assert.AreEqual(5, m3[1, 1], "wrong value [1, 1]");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultiplyExceptionTest()
        {
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m2 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            var m3 = m1 * m2;
        }

        [TestMethod]
        public void AddTest()
        {
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m2 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 0, 2, 1},
                new Vector<int>(3) { 1, 4, 1},
            };

            var m3 = m1 + m2;

            Assert.AreEqual(new Vector<int>(3) { 1, 4, 2 }, m3[0]);
            Assert.AreEqual(new Vector<int>(3) { 3, 3, 2 }, m3[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddExceptionTest()
        {
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m2 = new Matrix<int>(1, 3)
            {
                new Vector<int>(3) { 0, 2, 1},
            };

            var m3 = m1 + m2;
        }

        [TestMethod]
        public void MultiplyTestLong()
        {
            Matrix<int> m1 = new Matrix<int>(2, 100)
            {
                new Vector<int>(Enumerable.Repeat(1, 100)),
                new Vector<int>(Enumerable.Repeat(0, 100)),
            };

            Matrix<int> m2 = new Matrix<int>(
                Enumerable.Repeat(new Vector<int>(2) { 1, 0 }, 100)
                );

            var m3 = m1 * m2;

            Assert.AreEqual(100, m3[0, 0]);
            Assert.AreEqual(0, m3[0, 1]);
            Assert.AreEqual(0, m3[1, 0]);
            Assert.AreEqual(0, m3[1, 1]);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m2 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
            };

            Matrix<int> m3 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, 0, 1},
            };

            Matrix<int> m4 = new Matrix<int>(3, 3)
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
            Matrix<int> m1 = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
            };

            int idx = 0;
            foreach (var vec in m1)
                foreach (var item in vec)
                    Assert.AreEqual(idx++, item);
        }


        [TestMethod]
        public void AccessorTest()
        {
            Matrix<int> m = new Matrix<int>(2, 3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
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
            Matrix<int> m1 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            Matrix<int> m2 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            Matrix<int> m3 = new Matrix<int>(2, 2)
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
            Matrix<int> m1 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            Matrix<int> m2 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            Matrix<int> m3 = new Matrix<int>(2, 2)
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
            Matrix<int> m1 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            Matrix<int> m2 = new Matrix<int>(2, 2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            Matrix<int> m3 = new Matrix<int>(2, 2)
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
            Matrix<int> m = new Matrix<int>(3, 4)
            {
                new Vector<int>(4) { 10, 11, 12, 13},
                new Vector<int>(4) { 20, 21, 22, 23},
                new Vector<int>(4) { 30, 31, 32, 33}
            };

            Assert.AreEqual("[\n[10,11,12,13],\n[20,21,22,23],\n[30,31,32,33]\n]", m.ToString());
        }
    }
}