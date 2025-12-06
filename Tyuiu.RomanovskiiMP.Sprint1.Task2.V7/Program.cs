namespace Tyuiu.RomanovskiiMP.Sprint1.Task2.V7;
using System;

class CircleAreaCalculator
{
    static void Main()
    {
        try
        {
            Console.Write("Введите радиус круга (целое число): ");
            int radius = Convert.ToInt32(Console.ReadLine());

            if (radius < 0)
                throw new ArgumentException("Радиус не может быть отрицательным");

            double area = CalculateCircleArea(radius);
            Console.WriteLine($"Площадь круга: {Math.Round(area, 3)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception)
        {
            Console.WriteLine("Произошла неизвестная ошибка");
        }
    }

    static double CalculateCircleArea(int radius)
    {
        return Math.PI * radius * radius;
    }
}