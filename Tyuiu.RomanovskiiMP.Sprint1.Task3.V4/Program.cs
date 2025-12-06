using Tyuiu.RomanovskiiMP.Sprint1.Task3.V4.Lib;
using System;

namespace NotebookPurchaseCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа расчета стоимости покупки тетрадей и обложек");
            Console.WriteLine("======================================================\n");

            try
            {
                // Ввод данных пользователем
                double notebookPrice = GetPriceFromUser("Введите цену тетради (руб.): ");
                double coverPrice = GetPriceFromUser("Введите цену обложки (руб.): ");
                int quantity = GetQuantityFromUser("Введите количество комплектов (шт.): ");

                // Расчет стоимости
                double totalCost = CalculateTotalCost(notebookPrice, coverPrice, quantity);
                double roundedCost = Math.Round(totalCost, 3);

                // Вывод результатов
                DisplayResults(notebookPrice, coverPrice, quantity, roundedCost);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double GetPriceFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double price) || price < 0)
            {
                throw new ArgumentException("Цена должна быть положительным числом");
            }

            return price;
        }

        static int GetQuantityFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int quantity) || quantity < 0)
            {
                throw new ArgumentException("Количество должно быть целым положительным числом");
            }

            return quantity;
        }

        static double CalculateTotalCost(double notebookPrice, double coverPrice, int quantity)
        {
            // Стоимость одного комплекта: тетрадь + обложка
            double costPerSet = notebookPrice + coverPrice;

            // Общая стоимость: стоимость комплекта × количество
            return costPerSet * quantity;
        }

        static void DisplayResults(double notebookPrice, double coverPrice, int quantity, double totalCost)
        {
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("               РЕЗУЛЬТАТЫ");
            Console.WriteLine("═══════════════════════════════════════════");

            Console.WriteLine($"Цена тетради:        {notebookPrice:F2} руб.");
            Console.WriteLine($"Цена обложки:        {coverPrice:F2} руб.");
            Console.WriteLine($"Количество комплектов: {quantity} шт.");
            Console.WriteLine("───────────────────────────────────────────");

            // Детализация расчета
            double costPerSet = notebookPrice + coverPrice;
            Console.WriteLine($"Стоимость 1 комплекта: {costPerSet:F2} руб.");
            Console.WriteLine($"Общая стоимость:     {totalCost:F3} руб.");
            Console.WriteLine("═══════════════════════════════════════════");

            // Проверка на пример из задания
            if (Math.Abs(notebookPrice - 2.75) < 0.001 &&
                Math.Abs(coverPrice - 0.5) < 0.001 &&
                quantity == 7)
            {
                Console.WriteLine("\n✓ Результат совпадает с примером из задания!");
            }
        }
    }
}