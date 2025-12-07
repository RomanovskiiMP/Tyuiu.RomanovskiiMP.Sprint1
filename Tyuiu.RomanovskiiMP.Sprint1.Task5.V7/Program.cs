using System;

namespace HourHandCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа вычисления времени по углу поворота часовой стрелки");
            Console.WriteLine("==============================================================\n");

            try
            {
                // Ввод угла поворота часовой стрелки
                Console.Write("Введите угол поворота часовой стрелки f (0 < f < 360 градусов): ");
                double angle = GetAngleFromUser();

                // Вычисление времени
                double totalHours = CalculateHoursFromAngle(angle);

                // Разделение на часы и минуты
                int wholeHours = (int)Math.Floor(totalHours);
                double fractionalHours = totalHours - wholeHours;
                int minutes = (int)Math.Round(fractionalHours * 60);

                // Вывод результатов
                DisplayResults(angle, totalHours, wholeHours, minutes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double GetAngleFromUser()
        {
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double angle))
            {
                throw new FormatException("Некорректный ввод. Введите число.");
            }

            // Проверка диапазона: 0 < f < 360
            if (angle <= 0 || angle >= 360)
            {
                throw new ArgumentException("Угол должен быть в диапазоне: 0 < f < 360 градусов.");
            }

            return angle;
        }

        static double CalculateHoursFromAngle(double angle)
        {
            // За 12 часов часовая стрелка делает полный оборот (360 градусов)
            // Угловая скорость: 360 градусов / 12 часов = 30 градусов/час

            const double degreesPerHour = 30.0; // 360° / 12ч = 30°/ч

            // Время в часах: угол / скорость
            double hours = angle / degreesPerHour;

            return hours;
        }

        static void DisplayResults(double angle, double totalHours, int hours, int minutes)
        {
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("               РЕЗУЛЬТАТЫ");
            Console.WriteLine("═══════════════════════════════════════════");

            Console.WriteLine($"Входные данные:");
            Console.WriteLine($"  Угол поворота часовой стрелки: f = {angle}°");

            Console.WriteLine($"\nРасчет:");
            Console.WriteLine($"  Полный оборот (360°) соответствует 12 часам");
            Console.WriteLine($"  Скорость поворота: 360° / 12ч = 30°/ч");
            Console.WriteLine($"  Время = угол / скорость = {angle}° / 30°/ч");

            Console.WriteLine($"\nРезультат:");
            Console.WriteLine($"  Полное количество часов: {totalHours:F4} ч");

            if (totalHours >= 12)
            {
                Console.WriteLine("\n⚠ Внимание: результат больше 12 часов!");
                Console.WriteLine("  По условию задача решается для первой половины дня.");
                Console.WriteLine("  Для углов больше 180° результат будет во второй половине дня.");
            }

            Console.WriteLine($"\nВремя в формате ЧЧ:ММ:");

            // Корректировка для 12-часового формата
            int displayHours = hours % 12;
            if (displayHours == 0) displayHours = 12;

            string amPm = hours < 12 ? "утра" : "дня";

            Console.WriteLine($"  {displayHours:D2}:{minutes:D2} {amPm}");
            Console.WriteLine($"  ({hours} часов {minutes} минут)");

            // Проверка особых углов
            if (Math.Abs(angle % 30) < 0.001)
            {
                Console.WriteLine($"\nℹ️  Особый случай: угол кратен 30°");
                Console.WriteLine($"  Часовая стрелка точно на цифре циферблата");
            }

            Console.WriteLine("═══════════════════════════════════════════");
        }
    }
}