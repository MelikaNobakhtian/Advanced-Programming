using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A8Tests;

namespace A8.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            Human testhuman = new Human("Mahya", "Karimi", 170, new DateTime(1998, 5, 5));
            Assert.AreEqual(testhuman.FirstName, "Mahya");
            Assert.AreEqual(testhuman.LastName, "Karimi");
            Assert.AreEqual(testhuman.Height, 170);
            Assert.AreEqual(testhuman.BirthDate, new DateTime(1998, 5, 5));
        }

        [TestMethod()]
        public void EqualOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsTrue(human == HumanData.SameHuman);
            Assert.IsFalse(human == HumanData.DayHuman);
            Assert.IsFalse(human == HumanData.YearHuman);
            Assert.IsFalse(human == HumanData.MonthHuman);
            Assert.IsTrue(HumanData.NullHuman == HumanData.NullHuman2);

        }

        [TestMethod()]
        public void PlusOperatorTest()
        {
            var human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            var human1 = new Human("Hamid", "Mohammadi", 180, new DateTime(2000, 6, 15));
            var child = human + human1;
            var expectedchild = new Human("ChildFirstName", "ChildLastName", 30, DateTime.Today);
            Assert.AreEqual(child, expectedchild);

        }

        [TestMethod()]
        public void SmallerOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsTrue(human < HumanData.GreaterDay);
            Assert.IsTrue(human < HumanData.GreaterMonth);
            Assert.IsTrue(human < HumanData.GreaterYear);
            Assert.IsFalse(human < HumanData.SmallerDay);
            Assert.IsFalse(human < HumanData.SmallerMonth);
            Assert.IsFalse(human < HumanData.SmallerYear);
            Assert.IsFalse(human < HumanData.SameHuman);
            Assert.IsFalse(human < HumanData.NullHuman);

        }

        [TestMethod()]
        public void GreaterOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsFalse(human > HumanData.GreaterDay);
            Assert.IsFalse(human > HumanData.GreaterMonth);
            Assert.IsFalse(human > HumanData.GreaterYear);
            Assert.IsTrue(human > HumanData.SmallerDay);
            Assert.IsTrue(human > HumanData.SmallerMonth);
            Assert.IsTrue(human > HumanData.SmallerYear);
            Assert.IsFalse(human > HumanData.SameHuman);
            Assert.IsFalse(human > HumanData.NullHuman);

        }

        [TestMethod()]
        public void SmallerOrEqualOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsTrue(human <= HumanData.GreaterDay);
            Assert.IsTrue(human <= HumanData.GreaterMonth);
            Assert.IsTrue(human <= HumanData.GreaterYear);
            Assert.IsFalse(human <= HumanData.SmallerDay);
            Assert.IsFalse(human <= HumanData.SmallerMonth);
            Assert.IsFalse(human <= HumanData.SmallerYear);
            Assert.IsTrue(human <= HumanData.SameHuman);

        }

        [TestMethod()]
        public void GreaterOrEqualOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsFalse(human >= HumanData.GreaterDay);
            Assert.IsFalse(human >= HumanData.GreaterMonth);
            Assert.IsFalse(human >= HumanData.GreaterYear);
            Assert.IsTrue(human >= HumanData.SmallerDay);
            Assert.IsTrue(human >= HumanData.SmallerMonth);
            Assert.IsTrue(human >= HumanData.SmallerYear);
            Assert.IsTrue(human >= HumanData.SameHuman);

        }

        [TestMethod()]
        public void NotEqualOperatorTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.IsFalse(human != HumanData.SameHuman);
            Assert.IsTrue(human != HumanData.DayHuman);
            Assert.IsTrue(human != HumanData.YearHuman);
            Assert.IsTrue(human != HumanData.MonthHuman);

        }


        [TestMethod()]
        public void EqualsTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            Assert.AreEqual(true, human.Equals(HumanData.SameHuman));
            Assert.AreEqual(false, human.Equals(HumanData.FirstNameHuman));
            Assert.AreEqual(false, human.Equals(HumanData.LastNameHuman));
            Assert.AreEqual(false, human.Equals(HumanData.HeightHuman));
            Assert.AreEqual(false, human.Equals(HumanData.YearHuman));
            Assert.AreEqual(false, human.Equals(HumanData.MonthHuman));
            Assert.AreEqual(false, human.Equals(HumanData.DayHuman));
            Assert.AreEqual(false, human.Equals(HumanData.NullHuman));

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Human human = new Human("Sara", "Ghasemi", 165, new DateTime(2001, 4, 11));
            var h1 = HumanData.SameHuman.GetHashCode();
            var h2 = HumanData.SmallerDay.GetHashCode();
            var h3 = HumanData.SmallerMonth.GetHashCode();
            Assert.AreNotEqual(human.GetHashCode(), h2);
            Assert.AreEqual(human.GetHashCode(), h1);
            Assert.AreNotEqual(human.GetHashCode(), h3);

        }
    }
}
