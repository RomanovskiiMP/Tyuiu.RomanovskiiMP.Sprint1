using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());

        double y = (2 + x) / 2;

        Console.WriteLine($"Результат: {y}");
    }
}