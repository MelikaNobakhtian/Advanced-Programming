using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1.Classes.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1Tests.Classes.Animals
{
    [TestClass()]
    public class PartridgeTests
    {
        Partridge partridge1 = new Partridge("Partridge 1", 22, 44.9, 90.9);
        Partridge partridge2 = new Partridge("Partridge 1", 23, 42.9, 89.9);

        [TestMethod()]
        public void EatFoodTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string partridge1Expected = $"{partridge1.Name} is a {typeof(Partridge).Name} and is eating";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is eating";

            // Act
            string partridge1Actual = partridge1.EatFood();
            string partridge2Actual = partridge2.EatFood();

            // Assert
            Assert.AreEqual(partridge1Expected, partridge1Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string partridge1And2Expected =
                $"{partridge1.Name} is a {typeof(Partridge).Name} and reproductive with {partridge2.Name}";

            // Act
            string partridge1And2Actual = partridge1.Reproduction(partridge2);

            // Assert
            Assert.AreEqual(partridge1And2Expected, partridge1And2Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
            //Assert.Inconclusive();

            // Arrange
            Partridge[] partridges = new[] { partridge1, partridge1};
            string[] expected = new[]
            {
                $"{partridge1.Name} is a {typeof(Partridge).Name} and is flying",
                $"{partridge1.Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment",
                $"{partridge1.Name} is a {typeof(Partridge).Name} and is walking",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and is flying",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment",
                $"{partridge2.Name} is a {typeof(Partridge).Name} and is walking",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Partridge partridge in partridges)
            {
                actual.Add(partridge.Move(E1.Enums.Environment.Air));
                actual.Add(partridge.Move(E1.Enums.Environment.Watery));
                actual.Add(partridge.Move(E1.Enums.Environment.Land));
            }

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void FlyTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string partridge1Expected = $"{partridge1.Name} is a {typeof(Partridge).Name} and is flying";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is flying";

            // Act
            string partridge1Actual = partridge1.Fly();
            string partridge2Actual = partridge2.Fly();

            // Assert
            Assert.AreEqual(partridge1Expected, partridge1Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }

        [TestMethod()]
        public void WalkTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string partridge1Expected = $"{partridge1.Name} is a {typeof(Partridge).Name} and is walking";
            string partridge2Expected = $"{partridge2.Name} is a {typeof(Partridge).Name} and is walking";

            // Act
            string partridge1Actual = partridge1.Walk();
            string partridge2Actual = partridge2.Walk();

            // Assert
            Assert.AreEqual(partridge1Expected, partridge1Actual);
            Assert.AreEqual(partridge2Expected, partridge2Actual);
        }
    }
}