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
    public class SnakeTests
    {
        Snake snake1 = new Snake("Snake 1", 45, 64, 69.3);
        Snake snake2 = new Snake("Snake 2", 75, 84, 68.9);

        [TestMethod()]
        public void EatFoodTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string snake1Expected = $"{snake1.Name} is a {typeof(Snake).Name} and is eating";
            string snake2Expected = $"{snake2.Name} is a {typeof(Snake).Name} and is eating";

            // Act
            string snake1Actual = snake1.EatFood();
            string snake2Actual = snake2.EatFood();

            // Assert
            Assert.AreEqual(snake1Expected, snake1Actual);
            Assert.AreEqual(snake2Expected, snake2Actual);
        }

        [TestMethod()]
        public void ReproductionTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string snake1And2Expected =
                $"{snake1.Name} is a {typeof(Snake).Name} and reproductive with {snake2.Name}";

            // Act
            string snake1And2Actual = snake1.Reproduction(snake2);

            // Assert
            Assert.AreEqual(snake1And2Expected, snake1And2Actual);
        }

        [TestMethod()]
        public void MoveTest()
        {
           // Assert.Inconclusive();

            // Arrange
            Snake[] snakes = new[] { snake1, snake2 };
            string[] expected = new[]
            {
                $"{snake1.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment",
                $"{snake1.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment",
                $"{snake1.Name} is a {typeof(Snake).Name} and is crawling",
                $"{snake2.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Air)} environment",
                $"{snake2.Name} is a {typeof(Snake).Name} and can't move in {Enum.GetName(typeof(E1.Enums.Environment), E1.Enums.Environment.Watery)} environment",
                $"{snake2.Name} is a {typeof(Snake).Name} and is crawling",
            };
            List<string> actual = new List<string>();

            // Act
            foreach (Snake snake in snakes)
            {
                actual.Add(snake.Move(E1.Enums.Environment.Air));
                actual.Add(snake.Move(E1.Enums.Environment.Watery));
                actual.Add(snake.Move(E1.Enums.Environment.Land));
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CrawlTest()
        {
           // Assert.Inconclusive();

            // Arrange
            string snake1Expected = $"{snake1.Name} is a {typeof(Snake).Name} and is crawling";
            string snake2Expected = $"{snake2.Name} is a {typeof(Snake).Name} and is crawling";

            // Act
            string snake1Actual = snake1.Crawl();
            string snake2Actual = snake2.Crawl();

            // Assert
            Assert.AreEqual(snake1Expected, snake1Actual);
            Assert.AreEqual(snake2Expected, snake2Actual);
        }
    }
}