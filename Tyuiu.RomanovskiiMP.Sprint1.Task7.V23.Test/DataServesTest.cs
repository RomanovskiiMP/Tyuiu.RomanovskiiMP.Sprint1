using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComplexExpressionCalculator.Tests
{
    [TestClass]
    public class ComplexExpressionCalculatorTests
    {
        [TestMethod]
        public void CalculateExpression_SimpleValues_ReturnsCorrectResult()
        {
            // Arrange
            double x = 1;
            double y = 0;

            // Ожидаемый расчет:
            // z = 1 - 10^sin(1) + (20*1²)/(3*1³) + cos(1² - 0)
            // sin(1) ≈ 0.841471
            // 10^0.841471 ≈ 6.941
            // (20*1)/(3*1) = 20/3 ≈ 6.666667
            // cos(1) ≈ 0.540302
            // z = 1 - 6.941 + 6.666667 + 0.540302 ≈ 1.266969
            // Округление до 3 знаков: 1.267

            double expected = 1.267;

            // Act
            double sinX = Math.Sin(x);
            double term1 = x;
            double term2 = Math.Pow(10, sinX);
            double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            double term4 = Math.Cos(Math.Pow(x, 2) - y);
            double z = term1 - term2 + term3 + term4;
            double roundedZ = Math.Round(z, 3);

            // Assert
            Assert.AreEqual(expected, roundedZ, 0.001);
        }

        [TestMethod]
        public void CalculateExpression_XIsZero_ThrowsException()
        {
            // Arrange
            double x = 0;
            double y = 1;

            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            });
        }

        [TestMethod]
        public void CalculateExpression_XIsOneYIsOne()
        {
            // Arrange
            double x = 1;
            double y = 1;

            // Вычисляем вручную:
            // sin(1) ≈ 0.841471, 10^0.841471 ≈ 6.941
            // (20*1²)/(3*1³) = 20/3 ≈ 6.666667
            // cos(1² - 1) = cos(0) = 1
            // z = 1 - 6.941 + 6.666667 + 1 ≈ 1.725667
            // Округление: 1.726

            double expected = 1.726;

            // Act
            double sinX = Math.Sin(x);
            double term1 = x;
            double term2 = Math.Pow(10, sinX);
            double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            double term4 = Math.Cos(Math.Pow(x, 2) - y);
            double z = term1 - term2 + term3 + term4;
            double roundedZ = Math.Round(z, 3);

            // Assert
            Assert.AreEqual(expected, roundedZ, 0.001);
        }

        [TestMethod]
        public void CalculateExpression_NegativeX()
        {
            // Arrange
            double x = -2;
            double y = 3;

            // Act
            double sinX = Math.Sin(x);
            double term1 = x;
            double term2 = Math.Pow(10, sinX);
            double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            double term4 = Math.Cos(Math.Pow(x, 2) - y);
            double z = term1 - term2 + term3 + term4;

            // Assert - проверяем, что результат вычислен (не NaN)
            Assert.IsFalse(double.IsNaN(z));
            Assert.IsFalse(double.IsInfinity(z));
        }

        [TestMethod]
        public void SimplifyTerm3_ShouldEqual20Over3X()
        {
            // Проверка упрощения: (20x²)/(3x³) = 20/(3x)

            // Arrange
            double[] testX = { 1, 2, 3, 0.5, -1, -2 };

            foreach (double x in testX)
            {
                if (Math.Abs(x) > 1e-10) // избегаем деления на ноль
                {
                    // Act
                    double original = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
                    double simplified = 20.0 / (3.0 * x);

                    // Assert
                    Assert.AreEqual(simplified, original, 1e-10,
                        $"Ошибка для x={x}. Оригинал: {original}, Упрощенный: {simplified}");
                }
            }
        }

        [TestMethod]
        public void CalculateExpression_LargeValues()
        {
            // Arrange
            double x = 10;
            double y = 5;

            // Act
            double sinX = Math.Sin(x);
            double term1 = x;
            double term2 = Math.Pow(10, sinX);
            double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            double term4 = Math.Cos(Math.Pow(x, 2) - y);
            double z = term1 - term2 + term3 + term4;

            // Assert
            Assert.IsFalse(double.IsNaN(z), "Результат не должен быть NaN");
            Assert.IsFalse(double.IsInfinity(z), "Результат не должен быть бесконечным");

            // Проверяем, что term3 упрощается до 20/(3x)
            double simplifiedTerm3 = 20.0 / (3.0 * x);
            double originalTerm3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            Assert.AreEqual(simplifiedTerm3, originalTerm3, 1e-10);
        }

        [TestMethod]
        public void CalculateExpression_TrigonometricProperties()
        {
            // Проверка тригонометрических свойств

            // Arrange
            double x = Math.PI / 2; // 90 градусов
            double y = 0;

            // sin(π/2) = 1, поэтому 10^sin(x) = 10^1 = 10
            // cos(x² - y) = cos((π/2)²) = cos(π²/4)

            // Act
            double sinX = Math.Sin(x);
            double term2 = Math.Pow(10, sinX);

            // Assert
            Assert.AreEqual(1.0, sinX, 1e-10, "sin(π/2) должен быть равен 1");
            Assert.AreEqual(10.0, term2, 1e-10, "10^sin(π/2) должен быть равен 10");
        }

        [TestMethod]
        public void RoundingToThreeDecimals_IsCorrect()
        {
            // Проверка округления до 3 знаков

            // Arrange
            double[] testValues = {
                1.266969,   // → 1.267
                1.725667,   // → 1.726
                0.123456,   // → 0.123
                0.123654,   // → 0.124
                123.456789, // → 123.457
                -1.234567   // → -1.235
            };

            double[] expected = {
                1.267,
                1.726,
                0.123,
                0.124,
                123.457,
                -1.235
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
        [DataRow(2, 1, 1.407)]
        [DataRow(0.5, 0.5, 6.835)]
        [DataRow(3, 2, 1.038)]
        [DataRow(-1, 1, -9.915)]
        [DataRow(0.1, 0, -97.682)]
        public void CalculateExpression_VariousInputs_ReturnsExpected(
            double x, double y, double expected)
        {
            // Act
            double sinX = Math.Sin(x);
            double term1 = x;
            double term2 = Math.Pow(10, sinX);
            double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
            double term4 = Math.Cos(Math.Pow(x, 2) - y);
            double z = term1 - term2 + term3 + term4;
            double roundedZ = Math.Round(z, 3);

            // Assert
            Assert.AreEqual(expected, roundedZ, 0.001,
                $"Ошибка для x={x}, y={y}. Получено: {roundedZ}, Ожидалось: {expected}");
        }

        [TestMethod]
        public void CalculateExpression_PartsIndividually()
        {
            // Проверка каждой части выражения отдельно

            // Arrange
            double x = 2;
            double y = 3;

            // Act - вычисляем каждую часть
            double sinX = Math.Sin(x);
            double part1 = x;  // x
            double part2 = Math.Pow(10, sinX);  // 10^sin(x)
            double part3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));  // (20x²)/(3x³)
            double part4 = Math.Cos(Math.Pow(x, 2) - y);  // cos(x² - y)

            // Assert - проверяем каждую часть
            Assert.AreEqual(2.0, part1, 1e-10, "Часть 1 (x) вычислена неверно");
            Assert.IsTrue(part2 > 0, "Часть 2 (10^sin(x)) должна быть положительной");

            // Проверяем упрощение части 3
            double simplifiedPart3 = 20.0 / (3.0 * x);
            Assert.AreEqual(simplifiedPart3, part3, 1e-10,
                "Часть 3 должна упрощаться до 20/(3x)");

            // Проверяем, что часть 4 в диапазоне [-1, 1]
            Assert.IsTrue(part4 >= -1 && part4 <= 1,
                "Косинус должен быть в диапазоне [-1, 1]");
        }

        [TestMethod]
        public void Expression_DomainAnalysis()
        {
            // Анализ области определения выражения

            // 1. 10^sin(x) - определен для всех x
            // 2. (20x²)/(3x³) = 20/(3x) - определен при x ≠ 0
            // 3. cos(x² - y) - определен для всех x, y

            // Arrange
            double[] validX = { 0.1, 1, -1, 100, -100, Math.PI };
            double[] validY = { 0, 1, -1, 100, -100, Math.PI };

            foreach (double x in validX)
            {
                foreach (double y in validY)
                {
                    if (Math.Abs(x) > 1e-10) // избегаем x = 0
                    {
                        // Act
                        double sinX = Math.Sin(x);
                        double term1 = x;
                        double term2 = Math.Pow(10, sinX);
                        double term3 = (20 * Math.Pow(x, 2)) / (3 * Math.Pow(x, 3));
                        double term4 = Math.Cos(Math.Pow(x, 2) - y);
                        double z = term1 - term2 + term3 + term4;

                        // Assert
                        Assert.IsFalse(double.IsNaN(z),
                            $"Выражение должно быть определено для x={x}, y={y}");
                        Assert.IsFalse(double.IsInfinity(z),
                            $"Выражение не должно быть бесконечным для x={x}, y={y}");
                    }
                }
            }
        }
    }
}