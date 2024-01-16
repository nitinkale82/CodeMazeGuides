using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GivenStringWithNumbers_WhenExtractingNumbers_ThenNumbersFound()
        {
            // Arrange
            string input = "The price is $123.45";

            var positive = int.IsPositive(-1); // false
            var negative = int.IsNegative(-1); // true

            // Act
            string result = Program.FindNumberRegExMethod(input);

            // Assert
            Assert.AreEqual("Found numbers: 123.45", result);
        }
        [TestMethod()]
        public void GivenStringWithoutNumbers_WhenExtractingNumbers_ThenNoNumbersFound()
        {
            // Arrange
            string input = "No numbers in this string";

            // Act
            string result = Program.FindNumberRegExMethod(input);

            // Assert
            Assert.AreEqual("No numbers found in the string.", result);
        }
        [TestMethod()]
        public void GivenStringWithNumbers_WhenExtractingNumbersUsingLinq_ThenNumbersFound()
        {
            // Arrange
            string input = "The price is $123.45";

            // Act
            string result = Program.FindNumberLinqMethod(input);

            // Assert
            Assert.AreEqual("Found numbers: 123, 45", result);
        }
        [TestMethod()]
        public void GivenStringWithoutNumbers_WhenExtractingNumbersUsingLinq_ThenNoNumbersFound()
        {
            // Arrange
            string input = "No numbers in this string";

            // Act
            string result = Program.FindNumberLinqMethod(input);

            // Assert
            Assert.AreEqual("No numbers found in the string.", result);
        }
    }
}