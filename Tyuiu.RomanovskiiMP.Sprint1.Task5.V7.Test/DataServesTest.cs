using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HourHandCalculator.Tests
{
    [TestClass]
    public class HourHandCalculatorTests
    {
        [TestMethod]
        public void CalculateHoursFromAngle_30Degrees_Returns1Hour()
        {
            // Arrange
            double angle = 30;
            double expected = 1.0; // 30° / 30°/ч = 1 час

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_90Degrees_Returns3Hours()
        {
            // Arrange
            double angle = 90;
            double expected = 3.0; // 90° / 30°/ч = 3 часа

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_180Degrees_Returns6Hours()
        {
            // Arrange
            double angle = 180;
            double expected = 6.0; // 180° / 30°/ч = 6 часов

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_15Degrees_Returns0_5Hours()
        {
            // Arrange
            double angle = 15;
            double expected = 0.5; // 15° / 30°/ч = 0.5 часа = 30 минут

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_270Degrees_Returns9Hours()
        {
            // Arrange
            double angle = 270;
            double expected = 9.0; // 270° / 30°/ч = 9 часов

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_45Degrees_Returns1_5Hours()
        {
            // Arrange
            double angle = 45;
            double expected = 1.5; // 45° / 30°/ч = 1.5 часа = 1 час 30 минут

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_1Degree_Returns0_0333Hours()
        {
            // Arrange
            double angle = 1;
            double expected = 0.0333333333; // 1° / 30°/ч ≈ 0.033333 часа

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_359Degrees_Returns11_9667Hours()
        {
            // Arrange
            double angle = 359;
            double expected = 11.9666666667; // 359° / 30°/ч ≈ 11.9667 часа

            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void ConvertHoursToHoursMinutes_1_5Hours_Returns1Hour30Minutes()
        {
            // Arrange
            double totalHours = 1.5;
            int expectedHours = 1;
            int expectedMinutes = 30;

            // Act
            int hours = (int)Math.Floor(totalHours);
            double fractionalHours = totalHours - hours;
            int minutes = (int)Math.Round(fractionalHours * 60);

            // Assert
            Assert.AreEqual(expectedHours, hours);
            Assert.AreEqual(expectedMinutes, minutes);
        }

        [TestMethod]
        public void ConvertHoursToHoursMinutes_2_75Hours_Returns2Hours45Minutes()
        {
            // Arrange
            double totalHours = 2.75;
            int expectedHours = 2;
            int expectedMinutes = 45; // 0.75 * 60 = 45

            // Act
            int hours = (int)Math.Floor(totalHours);
            double fractionalHours = totalHours - hours;
            int minutes = (int)Math.Round(fractionalHours * 60);

            // Assert
            Assert.AreEqual(expectedHours, hours);
            Assert.AreEqual(expectedMinutes, minutes);
        }

        [TestMethod]
        public void CalculateHoursFromAngle_SmallAngle_ReturnsProportionalTime()
        {
            // Проверка пропорциональности: угол ∝ время

            // Arrange
            double angle1 = 30;
            double angle2 = 60;

            // Act
            double time1 = angle1 / 30;
            double time2 = angle2 / 30;

            // Assert: время должно быть пропорционально углу
            Assert.AreEqual(2 * time1, time2, 0.0001,
                "Время должно быть прямо пропорционально углу");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateAngle_ZeroDegrees_ThrowsException()
        {
            // Arrange
            double angle = 0;

            // Act & Assert
            if (angle <= 0 || angle >= 360)
            {
                throw new ArgumentException("Угол должен быть в диапазоне: 0 < f < 360 градусов.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateAngle_360Degrees_ThrowsException()
        {
            // Arrange
            double angle = 360;

            // Act & Assert
            if (angle <= 0 || angle >= 360)
            {
                throw new ArgumentException("Угол должен быть в диапазоне: 0 < f < 360 градусов.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateAngle_NegativeDegrees_ThrowsException()
        {
            // Arrange
            double angle = -10;

            // Act & Assert
            if (angle <= 0 || angle >= 360)
            {
                throw new ArgumentException("Угол должен быть в диапазоне: 0 < f < 360 градусов.");
            }
        }

        [TestMethod]
        public void BoundaryAngles_CorrectCalculation()
        {
            // Тестирование граничных значений (близких к 0 и 360)

            // Arrange
            double smallAngle = 0.1;
            double largeAngle = 359.9;

            // Act
            double timeSmall = smallAngle / 30;
            double timeLarge = largeAngle / 30;

            // Assert
            Assert.IsTrue(timeSmall > 0, "Для малых углов время должно быть положительным");
            Assert.IsTrue(timeLarge < 12, "Для углов близких к 360° время должно быть меньше 12 часов");
            Assert.AreEqual(11.9966666667, timeLarge, 0.0001);
        }

        [TestMethod]
        [DataRow(30, 1.0)]      // 30° → 1 час
        [DataRow(60, 2.0)]      // 60° → 2 часа
        [DataRow(90, 3.0)]      // 90° → 3 часа
        [DataRow(120, 4.0)]     // 120° → 4 часа
        [DataRow(150, 5.0)]     // 150° → 5 часов
        [DataRow(180, 6.0)]     // 180° → 6 часов
        [DataRow(210, 7.0)]     // 210° → 7 часов
        [DataRow(240, 8.0)]     // 240° → 8 часов
        [DataRow(270, 9.0)]     // 270° → 9 часов
        [DataRow(300, 10.0)]    // 300° → 10 часов
        [DataRow(330, 11.0)]    // 330° → 11 часов
        public void CalculateHoursFromAngle_MultiplesOf30_ReturnsIntegerHours(
            double angle, double expectedHours)
        {
            // Act
            double result = angle / 30;

            // Assert
            Assert.AreEqual(expectedHours, result, 0.0001,
                $"Ошибка для угла {angle}°. Получено: {result}, Ожидалось: {expectedHours}");
        }

        [TestMethod]
        public void PhysicalInterpretation_MatchesClockBehavior()
        {
            // Проверка физической интерпретации:
            // За 1 час стрелка поворачивается на 30°
            // За 12 часов - на 360° (полный оборот)

            // Arrange
            double[] testAngles = { 30, 60, 90, 180, 270, 360 };
            double[] expectedTimes = { 1, 2, 3, 6, 9, 12 };

            for (int i = 0; i < testAngles.Length; i++)
            {
                // Act
                double time = testAngles[i] / 30;

                // Assert
                Assert.AreEqual(expectedTimes[i], time, 0.0001,
                    $"Физическая интерпретация: угол {testAngles[i]}° должен соответствовать {expectedTimes[i]} часам");
            }
        }
    }
}