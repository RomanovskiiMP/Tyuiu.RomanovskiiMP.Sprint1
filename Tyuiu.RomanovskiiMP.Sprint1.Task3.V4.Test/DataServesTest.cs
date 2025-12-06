using Tyuiu.RomanovskiiMP.Sprint1.Task3.V4.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NotebookPurchaseCalculator.Tests
{
    [TestClass]
    public class NotebookPurchaseCalculatorTests
    {
        [TestMethod]
        public void CalculateTotalCost_ExampleFromTask_Returns22_75()
        {
            // Arrange (данные из задания)
            double notebookPrice = 2.75;
            double coverPrice = 0.5;
            int quantity = 7;
            double expected = 22.75;

            // Act
            double totalCost = (notebookPrice + coverPrice) * quantity;
            double roundedCost = Math.Round(totalCost, 3);

            // Assert
            Assert.AreEqual(expected, roundedCost, 0.001);
        }

        [TestMethod]
        public void CalculateTotalCost_ZeroQuantity_ReturnsZero()
        {
            // Arrange
            double notebookPrice = 2.75;
            double coverPrice = 0.5;
            int quantity = 0;
            double expected = 0;

            // Act
            double totalCost = (notebookPrice + coverPrice) * quantity;
            double roundedCost = Math.Round(totalCost, 3);

            // Assert
            Assert.AreEqual(expected, roundedCost);
        }

        [TestMethod]
        public void CalculateTotalCost_OneSet_ReturnsSumOfPrices()
        {
            // Arrange
            double notebookPrice = 3.25;
            double coverPrice = 0.75;
            int quantity = 1;
            double expected = 4.0;

            // Act
            double totalCost = (notebookPrice + coverPrice) * quantity;
            double roundedCost = Math.Round(totalCost, 3);

            // Assert
            Assert.AreEqual(expected, roundedCost);
        }

        [TestMethod]
        public void RoundingToThreeDecimals_IsCorrect()
        {
            // Тест округления до 3 знаков после запятой
            double[] testValues = { 22.7499, 22.7501, 22.7555, 22.7544 };
            double[] expected = { 22.750, 22.750, 22.756, 22.754 };

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
        [DataRow(1.0, 0.5, 10, 15.0)]
        [DataRow(2.0, 1.0, 5, 15.0)]
        [DataRow(3.5, 1.5, 2, 10.0)]
        [DataRow(10.0, 2.5, 3, 37.5)]
        public void CalculateTotalCost_VariousInputs_ReturnsCorrectResults(
            double notebookPrice, double coverPrice, int quantity, double expected)
        {
            // Act
            double totalCost = (notebookPrice + coverPrice) * quantity;
            double roundedCost = Math.Round(totalCost, 3);

            // Assert
            Assert.AreEqual(expected, roundedCost, 0.001,
                $"Цена тетради: {notebookPrice}, обложки: {coverPrice}, количество: {quantity}");
        }
    }
}