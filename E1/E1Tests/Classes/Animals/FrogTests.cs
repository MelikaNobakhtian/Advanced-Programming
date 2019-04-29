using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1.Classes.Animals;
using E1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1Tests.Classes.Animals
{
    [TestClass()]
    public class FrogTests
    {
        Frog frog1 = new Frog("Mr Goorghoori", 2, 42.2, 30);
        Frog frog2 = new Frog("Mrs Goorghoori", 1, 92.2, 20);

        [TestMethod()]
        public void EatFoodTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string frog1Expected = $"{frog1.Name} is a {typeof(Frog).Name} and is eating";
            string frog2Expected = $"{frog2.Name} is a {typeof(Frog).Name} and is eating";

            // Act
            string frog1Actual = frog1.EatFood();
            string frog2Actual = frog2.EatFood();

            // Assert
            Assert.AreEqual(frog1Expected, frog1Actual);
            Assert.AreEqual(frog2Expected, frog2Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string frog1And2Expected = $"{frog1.Name} is a {typeof(Frog).Name} and reproductive with {frog2.Name}";

            // Act
            string frog1And2Actual = frog1.Reproduction(frog2);

            // Assert
            Assert.AreEqual(frog1And2Expected, frog1And2Actual);
        }

        [TestMethod()]
        public void SwimTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string frog1Expected = $"{frog1.Name} is a {typeof(Frog).Name} and is swimming";
            string frog2Expected = $"{frog2.Name} is a {typeof(Frog).Name} and is swimming";

            // Act
            string frog1Actual = frog1.Swim();
            string frog2Actual = frog2.Swim();

            //Assert 
            Assert.AreEqual(frog1Expected, frog1Actual);
            Assert.AreEqual(frog2Expected, frog2Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
           // Assert.Inconclusive();

            // Arrange
            Frog[] frogs = new[] { frog1, frog2};
            string[] expected = new[]
            {
                $"{frog1.Name} is a {typeof(Frog).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment",
                $"{frog1.Name} is a {typeof(Frog).Name} and is swimming",
                $"{frog1.Name} is a {typeof(Frog).Name} and is walking",
                $"{frog2.Name} is a {typeof(Frog).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment",
                $"{frog2.Name} is a {typeof(Frog).Name} and is swimming",
                $"{frog2.Name} is a {typeof(Frog).Name} and is walking",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Frog frog in frogs)
            {
                actual.Add(frog.Move(E1.Enums.Environment.Air));
                actual.Add(frog.Move(E1.Enums.Environment.Watery));
                actual.Add(frog.Move(E1.Enums.Environment.Land));
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void WalkTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string frog1Expected = $"{frog1.Name} is a {typeof(Frog).Name} and is walking";
            string frog2Expected = $"{frog2.Name} is a {typeof(Frog).Name} and is walking";

            // Act
            string frog1Actual = frog1.Walk();
            string frog2Actual = frog2.Walk();

            //Assert 
            Assert.AreEqual(frog1Expected, frog1Actual);
            Assert.AreEqual(frog2Expected, frog2Actual);
        }
    }
}