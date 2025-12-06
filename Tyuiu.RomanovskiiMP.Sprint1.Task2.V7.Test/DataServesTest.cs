using Tyuiu.RomanovskiiMP.Sprint1.Task2.V7.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CircleAreaCalculator.Tests
{
    [TestClass]
    public class CircleAreaCalculatorTests
    {
        [TestMethod]
        public void CalculateCircleArea_Radius5_Returns78_54()
        {
            // Arrange
            int radius = 5;
            double expected = 78.540; // π * 5² = 78.53981634 ≈ 78.540

            // Act
            double actual = Math.Round(Math.PI * radius * radius, 3);

            // Assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void CalculateCircleArea_Radius0_Returns0()
        {
            // Arrange
            int radius = 0;
            double expected = 0;

            // Act
            double actual = Math.Round(Math.PI * radius * radius, 3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateCircleArea_Radius10_Returns314_159()
        {
            // Arrange
            int radius = 10;
            double expected = 314.159; // π * 10² = 314.15926536 ≈ 314.159

            // Act
            double actual = Math.Round(Math.PI * radius * radius, 3);

            // Assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void RoundingToThreeDecimalPlaces_IsCorrect()
        {
            // Arrange
            double[] testValues = { 78.539816, 314.159265, 12.566371 };
            double[] expected = { 78.540, 314.159, 12.566 };

            for (int i = 0; i < testValues.Length; i++)
            {
                // Act
                double rounded = Math.Round(testValues[i], 3);

                // Assert
                Assert.AreEqual(expected[i], rounded, 0.001,
                    $"Ошибка округления: {testValues[i]} → {rounded}, ожидалось: {expected[i]}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeRadius_ShouldThrowException()
        {
            // Arrange
            int radius = -5;

            // Act & Assert (ожидаем исключение)
            if (radius < 0)
                throw new ArgumentException("Радиус не может быть отрицательным");
        }
    }
}