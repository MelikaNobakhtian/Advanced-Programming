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
    public class VectorTests
    {
        [TestMethod()]
        public void InitTest()
        {
            Vector<int> v = new Vector<int>(5) { 0, 1, 2, 3, 4 };
            for (int i = 0; i < v.Size; i++)
                Assert.AreEqual(i, v[i]);
        }

        [TestMethod()]
        public void CopyConstructorTest()
        {
            Vector<int> v = new Vector<int>(5) { 0, 1, 2, 3, 4 };
            Vector<int> vCopy = new Vector<int>(v);

            for (int i = 0; i < v.Size; i++)
                Assert.AreEqual(v[i], vCopy[i]);
        }

        [TestMethod()]
        public void IndexerTest()
        {
            Vector<int> v = new Vector<int>(5) { 0, 0, 0, 0, 0 };
            for (int i = 0; i < v.Size; i++)
                Assert.AreEqual(v[i], 0);

            for (int i = 0; i < v.Size; i++)
                v[i] = i;

            for (int i = 0; i < v.Size; i++)
                Assert.AreEqual(v[i], i);
        }

        [TestMethod()]
        public void AddTest()
        {
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v2 = new Vector<int>(5) { 5, 4, 3, 2, 1 };

            Vector<int> v = v1 + v2;

            Assert.AreEqual(v.Size, v1.Size);

            for (int i = 0; i < v.Size; i++)
                Assert.AreEqual(v[i], 6);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v2 = new Vector<int>(5) { 5, 4, 3, 2, 1 };

            int p = v1 * v2;

            Assert.AreEqual(35, p);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v2 = new Vector<int>(5) { 1, 2, 0, 4, 5 };
            Vector<int> v3 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v4 = new Vector<int>(6) { 1, 2, 3, 4, 5, 6 };

            Assert.AreEqual(v1, v3);
            Assert.AreNotEqual(v1, v2);

            Assert.IsTrue(v1 == v3);
            Assert.IsTrue(v1 != v2);

            Assert.IsFalse(v1 == v2);
            Assert.IsFalse(v1 != v3);

            Assert.AreNotEqual(v1, v4);
        }

        [TestMethod]
        public void IEnumerableTest()
        {
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };

            int idx = 1;
            foreach (var item in v1)
            {
                Assert.AreEqual(idx++, item);
            }
        }

        [TestMethod]
        public void HashCodeTest()
        {
            // Different vectors should have different hash codes
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v2 = new Vector<int>(6) { 1, 2, 3, 4, 5, 6 };

            Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());


            // Similar vectors should have similar hash codes
            Vector<int> v3 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Vector<int> v4 = new Vector<int>(5) { 1, 2, 3, 4, 5 };

            Assert.AreEqual(v3.GetHashCode(), v4.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Vector<int> v1 = new Vector<int>(5) { 1, 2, 3, 4, 5 };
            Assert.AreEqual("[1,2,3,4,5]", v1.ToString());
        }
    }
}