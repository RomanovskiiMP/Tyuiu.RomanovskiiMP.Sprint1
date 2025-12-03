
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathExpressionTests
{
    [TestClass]
    public class MathExpressionTests
    {
        [TestMethod]
        public void TestBasicExpression()
        {
            // Arrange (подготовка)
            int expected = 22;

            // Act (действие)
            int actual = 5 * 2 + 4 * 3;

            // Assert (проверка)
            Assert.AreEqual(expected, actual, "Выражение 5*2 + 4*3 вычислено неверно");
        }

        [TestMethod]
        public void TestExpressionWithStepByStep()
        {
            // Arrange
            int step1 = 5 * 2;    // 10
            int step2 = 4 * 3;    // 12
            int expected = 22;     // 10 + 12

            // Act
            int result1 = step1;
            int result2 = step2;
            int actual = result1 + result2;

            // Assert для каждого шага
            Assert.AreEqual(10, result1, "5 * 2 должно быть равно 10");
            Assert.AreEqual(12, result2, "4 * 3 должно быть равно 12");
            Assert.AreEqual(expected, actual, "Сумма 10 + 12 должна быть равна 22");
        }

        [TestMethod]
        public void TestExpressionOrderOfOperations()
        {
            // Проверка порядка операций (умножение выполняется перед сложением)
            int result1 = 5 * 2 + 4 * 3;    // Правильный порядок: (5*2) + (4*3) = 10 + 12 = 22
            int result2 = (5 * 2) + (4 * 3); // Явное указание порядка
            int result3 = 5 * (2 + 4) * 3;   // Другой порядок: 5 * 6 * 3 = 90

            Assert.AreEqual(22, result1, "Порядок операций не соблюден");
            Assert.AreEqual(22, result2, "Явный порядок операций дает другой результат");
            Assert.AreEqual(90, result3, "Измененный порядок операций вычислен неверно");
        }

        [TestMethod]
        public void TestMultipleExpressions()
        {
            // Тест нескольких выражений сразу
            var testCases = new[]
            {
                new { Expression = "5*2 + 4*3", Expected = 22 },
                new { Expression = "2*3 + 4*5", Expected = 26 },
                new { Expression = "1*1 + 2*2", Expected = 5 },
                new { Expression = "0*5 + 3*4", Expected = 12 }
            };

            foreach (var testCase in testCases)
            {
                // Разбираем выражение (в реальном проекте нужен парсер)
                int actual = 0;
                switch (testCase.Expression)
                {
                    case "5*2 + 4*3":
                        actual = 5 * 2 + 4 * 3;
                        break;
                    case "2*3 + 4*5":
                        actual = 2 * 3 + 4 * 5;
                        break;
                    case "1*1 + 2*2":
                        actual = 1 * 1 + 2 * 2;
                        break;
                    case "0*5 + 3*4":
                        actual = 0 * 5 + 3 * 4;
                        break;
                }

                Assert.AreEqual(testCase.Expected, actual,
                    $"Выражение {testCase.Expression} вычислено неверно");
            }
        }

        [TestMethod]
        public void TestExpressionPerformance()
        {
            // Тест производительности (выполнение 1000000 раз)
            int iterations = 1_000_000;
            int result = 0;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                result = 5 * 2 + 4 * 3;
            }

            stopwatch.Stop();

            // Проверка результата
            Assert.AreEqual(22, result, "Результат вычисления неверен после многократного выполнения");

            // Дополнительная проверка: время выполнения не должно быть слишком большим
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000,
                $"Вычисление заняло слишком много времени: {stopwatch.ElapsedMilliseconds}мс");

            Console.WriteLine($"Выражение вычислено {iterations} раз за {stopwatch.ElapsedMilliseconds}мс");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestExpressionWithLargeNumbers()
        {
            // Тест на переполнение
            checked
            {
                int max = int.MaxValue;
                int largeResult = max * 2; // Это вызовет OverflowException
            }
        }

        // Вспомогательный метод для вычисления выражения
        private int CalculateExpression(int a, int b, int c, int d)
        {
            return a * b + c * d;
        }

        [TestMethod]
        public void TestUsingHelperMethod()
        {
            // Использование вспомогательного метода
            int result = CalculateExpression(5, 2, 4, 3);
            Assert.AreEqual(22, result, "Вспомогательный метод вычисляет неверно");
        }

        [TestMethod]
        public void TestExpressionWithDifferentData()
        {
            // Data-Driven подход (можно было бы использовать DataTestMethod)
            TestExpressionWithValues(5, 2, 4, 3, 22);
            TestExpressionWithValues(1, 1, 1, 1, 2);
            TestExpressionWithValues(0, 5, 0, 3, 0);
            TestExpressionWithValues(10, 0, 5, 2, 10);
        }

        private void TestExpressionWithValues(int a, int b, int c, int d, int expected)
        {
            int actual = a * b + c * d;
            Assert.AreEqual(expected, actual,
                $"Выражение {a}*{b} + {c}*{d} вычислено неверно");
        }
    }
}