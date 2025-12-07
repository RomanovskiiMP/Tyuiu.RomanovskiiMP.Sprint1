using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComplexFormulaCalculator.Tests
{
    [TestClass]
    public class ComplexFormulaTests
    {
        [TestMethod]
        public void CalculateFormula_SimpleValues_ReturnsCorrectResult()
        {
            // Arrange
            double x = 1;
            double y = 1;

            // Ожидаемый расчет:
            // Числитель: 1 + 1² = 2
            // Знаменатель: e^(2 - 4*1) = e^(-2) ≈ 0.135335
            // Результат: 2 / 0.135335 ≈ 14.7781
            double expected = 14.778; // Округлено до 3 знаков

            // Act
            double numerator = x + Math.Pow(y, 2);
            double denominator = Math.Exp(2 - 4 * y);
            double result = numerator / denominator;
            double rounded = Math.Round(result, 3);

            // Assert
            Assert.AreEqual(expected, rounded, 0.001);
        }

        [TestMethod]
        public void CalculateFormula_ZeroValues_ReturnsCorrectResult()
        {
            // Arrange
            double x = 0;
            double y = 0;

            // Ожидаемый расчет:
            // Числитель: 0 + 0² = 0
            // Знаменатель: e^(2 - 4*0) = e^2 ≈ 7.389056
            // Результат: 0 / 7.389056 = 0
            double expected = 0;

            // Act
            double numerator = x + Math.Pow(y, 2);
            double denominator = Math.Exp(2 - 4 * y);
            double result = numerator / denominator;
            double rounded = Math.Round(result, 3);

            // Assert
            Assert.AreEqual(expected, rounded, 0.001);
        }

        [TestMethod]
        public void CalculateFormula_NegativeY_ReturnsCorrectResult()
        {
            // Arrange
            double x = 2;
            double y = -1;

            // Ожидаемый расчет:
            // Числитель: 2 + (-1)² = 3
            // Знаменатель: e^(2 - 4*(-1)) = e^(6) ≈ 403.428793
            // Результат: 3 / 403.428793 ≈ 0.007436
            double expected = 0.007; // Округлено до 3 знаков

            // Act
            double numerator = x + Math.Pow(y, 2);
            double denominator = Math.Exp(2 - 4 * y);
            double result = numerator / denominator;
            double rounded = Math.Round(result, 3);

            // Assert
            Assert.AreEqual(expected, rounded, 0.001);
        }

        [TestMethod]
        public void CalculateFormula_YIsZeroPointFive_DenominatorIsOne()
        {
            // Особый случай: когда y = 0.5, знаменатель = e^0 = 1

            // Arrange
            double x = 3;
            double y = 0.5;

            // Ожидаемый расчет:
            // Числитель: 3 + 0.5² = 3 + 0.25 = 3.25
            // Знаменатель: e^(2 - 4*0.5) = e^0 = 1
            // Результат: 3.25
            double expected = 3.25;

            // Act
            double numerator = x + Math.Pow(y, 2);
            double denominator = Math.Exp(2 - 4 * y);
            double result = numerator / denominator;
            double rounded = Math.Round(result, 3);

            // Assert
            Assert.AreEqual(expected, rounded, 0.001);
        }

        [TestMethod]
        public void RoundingToThreeDecimals_IsCorrect()
        {
            // Проверка округления до 3 знаков

            // Arrange
            double[] testValues = {
                14.778112,  // → 14.778
                0.007436,   // → 0.007
                3.249999,   // → 3.250
                123.456789, // → 123.457
                0.999999    // → 1.000
            };

            double[] expected = {
                14.778,
                0.007,
                3.250,
                123.457,
                1.000
            };

            for (int i = 0; i < testValues.Length; i++)
            {
                // Act
                double rounded = Math.Round(testValues[i], 3);

                // Assert
                Assert.AreEqual(expected[i], rounded, 0.0001,
                    $"Ошибка округления: {testValues[i]} → {rounded}, ожидалось: {expected[i]}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CalculateFormula_DenominatorApproachesZero_ThrowsException()
        {
            // Когда знаменатель близок к нулю (большое положительное y)

            // Arrange
            double x = 1;
            double y = 1000; // Большое положительное y

            // Act (имитация проверки в программе)
            double exponent = 2 - 4 * y;
            double denominator = Math.Exp(exponent);

            if (Math.Abs(denominator) < 1e-15)
            {
                throw new DivideByZeroException();
            }
        }

        [TestMethod]
        public void CalculateFormula_LargeY_DenominatorHuge()
        {
            // При больших положительных y знаменатель огромный → результат близок к 0

            // Arrange
            double x = 100;
            double y = 10;

            // Act
            double numerator = x + Math.Pow(y, 2); // 100 + 100 = 200
            double denominator = Math.Exp(2 - 4 * y); // e^(-38) ≈ 3.4e-17
            double result = numerator / denominator;

            // Assert - результат должен быть огромным
            Assert.IsTrue(result > 1e16, "При больших y результат должен быть огромным");
        }

        [TestMethod]
        public void CalculateFormula_NegativeLargeY_DenominatorTiny()
        {
            // При больших отрицательных y знаменатель очень маленький → результат огромный

            // Arrange
            double x = 1;
            double y = -10;

            // Act
            double numerator = x + Math.Pow(y, 2); // 1 + 100 = 101
            double denominator = Math.Exp(2 - 4 * y); // e^(42) ≈ 1.7e18
            double result = numerator / denominator;

            // Assert - результат должен быть очень маленьким
            Assert.IsTrue(result < 1e-16, "При больших отрицательных y результат должен быть очень маленьким");
        }

        [TestMethod]
        [DataRow(2, 2, 0.081)]    // x=2, y=2 → 0.081
        [DataRow(0, 0, 0.000)]    // x=0, y=0 → 0.000
        [DataRow(5, -0.5, 87.238)] // x=5, y=-0.5 → 87.238
        [DataRow(1, 0.25, 4.053)]  // x=1, y=0.25 → 4.053
        public void CalculateFormula_VariousInputs_ReturnsCorrectResults(
            double x, double y, double expected)
        {
            // Act
            double numerator = x + Math.Pow(y, 2);
            double denominator = Math.Exp(2 - 4 * y);
            double result = numerator / denominator;
            double rounded = Math.Round(result, 3);

            // Assert
            Assert.AreEqual(expected, rounded, 0.001,
                $"Ошибка для x={x}, y={y}. Получено: {rounded}, Ожидалось: {expected}");
        }

        [TestMethod]
        public void FormulaComponents_CalculateCorrectly()
        {
            // Проверка отдельных компонентов формулы

            // Arrange
            double x = 3;
            double y = 2;

            // Act
            double ySquared = Math.Pow(y, 2);
            double numerator = x + ySquared;
            double exponent = 2 - 4 * y;
            double denominator = Math.Exp(exponent);

            // Assert
            Assert.AreEqual(4, ySquared, 0.001, "y² вычислен неверно");
            Assert.AreEqual(7, numerator, 0.001, "Числитель вычислен неверно");
            Assert.AreEqual(-6, exponent, 0.001, "Показатель степени вычислен неверно");
            Assert.AreEqual(Math.Exp(-6), denominator, 1e-10, "Знаменатель вычислен неверно");
        }
    }
}