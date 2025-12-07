using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введите y: ");
        double y = double.Parse(Console.ReadLine());

        double numerator = x + Math.Pow(y, 2);
        double denominator = Math.Exp(2 - 4 * y);
        double result = numerator / denominator;

        double roundedResult = Math.Round(result, 3);

        Console.WriteLine($"Результат: {roundedResult}");
    }
}