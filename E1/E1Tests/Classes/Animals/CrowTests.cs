using System;
using System.Collections.Generic;
using E1.Classes.Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = E1.Enums.Environment;

namespace E1Tests.Classes.Animals
{

    [TestClass()]
    public class CrowTests
    {

        Crow crow1 = new Crow("Crow 1", 2, 98.1, 12);
        Crow crow2 = new Crow("Crow 2", 3, 50.6, 2);
        Crow crow3 = new Crow("Crow 3", 1, 92.1, 11);
        Crow crow4 = new Crow("Crow 4", 4, 18.0, 1);

        [TestMethod()]
        public void EatFoodTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string crow1Expected = $"{crow1.Name} is a {typeof(Crow).Name} and is eating";
            string crow2Expected = $"{crow2.Name} is a {typeof(Crow).Name} and is eating";
            string crow3Expected = $"{crow3.Name} is a {typeof(Crow).Name} and is eating";
            string crow4Expected = $"{crow4.Name} is a {typeof(Crow).Name} and is eating";


            // Act
            string crow1Actual = crow1.EatFood();
            string crow2Actual = crow2.EatFood();
            string crow3Actual = crow3.EatFood();
            string crow4Actual = crow4.EatFood();


            // Assert
            Assert.AreEqual(crow1Expected, crow1Actual);
            Assert.AreEqual(crow2Expected, crow2Actual);
            Assert.AreEqual(crow3Expected, crow3Actual);
            Assert.AreEqual(crow4Expected, crow4Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string crow1And2Expected = $"{crow1.Name} is a {typeof(Crow).Name} and reproductive with {crow2.Name}";
            string crow3And4Expected = $"{crow3.Name} is a {typeof(Crow).Name} and reproductive with {crow4.Name}";

            // Act
            string crow1And2Actual = crow1.Reproduction(crow2);
            string crow3And4Actual = crow3.Reproduction(crow4);

            // Assert
            Assert.AreEqual(crow1And2Expected, crow1And2Actual);
            Assert.AreEqual(crow3And4Expected, crow3And4Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
            //Assert.Inconclusive();

            // Arrange
            Crow[] crows = new[] {crow1, crow2, crow3, crow4};
            string[] expected = new[]
            {
                $"{crow1.Name} is a {typeof(Crow).Name} and is flying",
                $"{crow1.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment",
                $"{crow1.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment",
                $"{crow2.Name} is a {typeof(Crow).Name} and is flying",
                $"{crow2.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment",
                $"{crow2.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment",
                $"{crow3.Name} is a {typeof(Crow).Name} and is flying",
                $"{crow3.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment",
                $"{crow3.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment",
                $"{crow4.Name} is a {typeof(Crow).Name} and is flying",
                $"{crow4.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Watery)} environment",
                $"{crow4.Name} is a {typeof(Crow).Name} and can't move in {Enum.GetName(typeof(Environment), Environment.Land)} environment",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Crow crow in crows)
            {
                actual.Add(crow.Move(Environment.Air));
                actual.Add(crow.Move(Environment.Watery));
                actual.Add(crow.Move(Environment.Land));
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FlyTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string crow1Expected = $"{crow1.Name} is a {typeof(Crow).Name} and is flying";
            string crow2Expected = $"{crow2.Name} is a {typeof(Crow).Name} and is flying";
            string crow3Expected = $"{crow3.Name} is a {typeof(Crow).Name} and is flying";
            string crow4Expected = $"{crow4.Name} is a {typeof(Crow).Name} and is flying";


            // Act
            string crow1Actual = crow1.Fly();
            string crow2Actual = crow2.Fly();
            string crow3Actual = crow3.Fly();
            string crow4Actual = crow4.Fly();

            // Assert
            Assert.AreEqual(crow1Expected, crow1Actual);
            Assert.AreEqual(crow2Expected, crow2Actual);
            Assert.AreEqual(crow3Expected, crow3Actual);
            Assert.AreEqual(crow4Expected, crow4Actual);
        }
    }
}