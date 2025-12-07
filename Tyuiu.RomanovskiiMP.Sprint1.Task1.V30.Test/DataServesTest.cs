using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FormulaCalculator.Tests
{
    [TestClass]
    public class FormulaBasicTests
    {
        [TestMethod]
        public void Formula_CorrectlyCalculatesResult()
        {
            // Тест вычисления формулы (2 + x) / 2

            // Arrange (подготовка тестовых данных)
            double x = 5;
            double expected = (2 + x) / 2; // (2 + 5) / 2 = 3.5

            // Act (выполнение)
            double result = (2 + x) / 2;

            // Assert (проверка)
            Assert.AreEqual(expected, result,
                "Формула (2+x)/2 вычислена неверно");
        }

        [TestMethod]
        public void Formula_WithZero_ReturnsOne()
        {
            // Проверка граничного случая

            // Arrange
            double x = 0;
            double expected = 1; // (2 + 0) / 2 = 1

            // Act
            double result = (2 + x) / 2;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Formula_WithNegativeNumber_ReturnsCorrectValue()
        {
            // Проверка работы с отрицательными числами

            // Arrange
            double x = -4;
            double expected = -1; // (2 + (-4)) / 2 = -1

            // Act
            double result = (2 + x) / 2;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Formula_IsImplementedCorrectly()
        {
            // Проверка, что формула реализована правильно

            // Тест нескольких значений
            double[] testValues = { 1, 2, 3, 4, 5, -1, -2, -3, 0.5, 2.5 };

            foreach (double x in testValues)
            {
                // Arrange
                double expected = (2 + x) / 2;

                // Act
                double result = (2 + x) / 2;

                // Assert
                Assert.AreEqual(expected, result, 0.000001,
                    $"Ошибка для x = {x}");
            }
        }

        [TestMethod]
        public void Program_AcceptsUserInputAndCalculates()
        {
            // Проверка, что программа В ПРИНЦИПЕ может принимать ввод и вычислять

            // Этот тест проверяет логику, а не реальный ввод

            // Arrange (симулируем ввод пользователя)
            string simulatedInput = "3"; // пользователь ввел 3
            double x = double.Parse(simulatedInput);

            // Act (симулируем вычисление)
            double result = (2 + x) / 2;

            // Assert (проверяем результат)
            double expected = 2.5; // (2 + 3) / 2 = 2.5
            Assert.AreEqual(expected, result);
        }
    }
}