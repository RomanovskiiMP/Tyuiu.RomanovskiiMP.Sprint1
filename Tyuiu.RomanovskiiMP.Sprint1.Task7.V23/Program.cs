using System;

namespace ComplexExpressionCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа вычисления комплексного выражения:");
            Console.WriteLine("z = x - 10^sin(x) + (20x²)/(3x³) + cos(x² - y)");
            Console.WriteLine("===============================================\n");

            try
            {
                // Ввод данных от пользователя
                Console.Write("Введите значение x: ");
                double x = GetNumberFromUser();

                Console.Write("Введите значение y: ");
                double y = GetNumberFromUser();

                // Проверка на особые случаи
                if (Math.Abs(x) < 1e-15)
                {
                    Console.WriteLine("Внимание: x близко к нулю, возможны проблемы с делением.");
                }

                // Вычисление выражения
                double z = CalculateExpression(x, y);
                double roundedZ = Math.Round(z, 3);

                // Вывод результатов
                DisplayResults(x, y, z, roundedZ);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double GetNumberFromUser()
        {
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double number))
            {
                throw new FormatException("Некорректный ввод. Введите число.");
            }

            return number;
        }

        static double CalculateExpression(double x, double y)
        {
            // Вычисляем выражение по частям:
            // z = x - 10^sin(x) + (20x²)/(3x³) + cos(x² - y)

            // 1. Первая часть: x
            double part1 = x;

            // 2. Вторая часть: 10^sin(x)
            double sinX = Math.Sin(x);
            double part2 = Math.Pow(10, sinX);

            // 3. Третья часть: (20x²)/(3x³)
            if (Math.Abs(x) < 1e-15)
            {
                throw new DivideByZeroException("x близко к нулю, деление невозможно.");
            }

            double numerator = 20 * Math.Pow(x, 2);
            double denominator = 3 * Math.Pow(x, 3);
            double part3 = numerator / denominator;

            // Упрощаем: (20x²)/(3x³) = 20/(3x)
            double simplifiedPart3 = 20.0 / (3.0 * x);

            // 4. Четвертая часть: cos(x² - y)
            double argument = Math.Pow(x, 2) - y;
            double part4 = Math.Cos(argument);

            // Собираем все части
            double result = part1 - part2 + part3 + part4;

            Console.WriteLine("\nПромежуточные вычисления:");
            Console.WriteLine($"  1. x = {part1:F6}");
            Console.WriteLine($"  2. 10^sin({x}) = 10^{sinX:F6} = {part2:F6}");
            Console.WriteLine($"  3. (20·{x}²)/(3·{x}³) = {numerator:F6}/{denominator:F6} = {part3:F6}");
            Console.WriteLine($"     Упрощенная форма: 20/(3·{x}) = {simplifiedPart3:F6}");
            Console.WriteLine($"  4. cos({x}² - {y}) = cos({argument:F6}) = {part4:F6}");

            return result;
        }

        static void DisplayResults(double x, double y, double z, double roundedZ)
        {
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("               РЕЗУЛЬТАТЫ");
            Console.WriteLine("═══════════════════════════════════════════");

            Console.WriteLine($"Входные данные:");
            Console.WriteLine($"  x = {x}");
            Console.WriteLine($"  y = {y}");

            Console.WriteLine($"\nВыражение:");
            Console.WriteLine($"  z = x - 10^sin(x) + (20x²)/(3x³) + cos(x² - y)");

            Console.WriteLine($"\nПолный результат:");
            Console.WriteLine($"  z = {z:F10}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nРезультат (округлено до 3 знаков): {roundedZ}");
            Console.ResetColor();

            // Проверка на особые случаи
            if (double.IsNaN(z) || double.IsInfinity(z))
            {
                Console.WriteLine("\n⚠ Внимание: результат не определен!");
            }

            // Вывод упрощенной формулы
            Console.WriteLine($"\nУпрощенное выражение:");
            Console.WriteLine($"  z = x - 10^sin({x}) + 20/(3·{x}) + cos({x}² - {y})");
            Console.WriteLine($"  z = {x} - {Math.Pow(10, Math.Sin(x)):F6} + {20 / (3 * x):F6} + {Math.Cos(x * x - y):F6}");

            Console.WriteLine("═══════════════════════════════════════════");
        }
    }
}