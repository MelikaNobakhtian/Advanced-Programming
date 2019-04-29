using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1.Classes.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1Tests.Classes.Vehicles
{
    [TestClass()]
    public class SubmarineTests
    {
        Submarine submarine = new Submarine("Turtle", 100, 40.6);
        [TestMethod()]
        public void SwimTest()
        {
            //Assert.Inconclusive();

            // Arrange
            string expected =
                $"{submarine.Model} is a {typeof(Submarine).Name} and is swimming in {submarine.MaxDepthSupported} meter depth";

            // Act
            string actual = submarine.Swim();

            // Assert
            Assert.AreEqual(expected,actual);
        }
    }
}