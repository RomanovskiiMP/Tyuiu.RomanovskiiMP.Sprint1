using System;

namespace FirstLetterChecker
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа проверки: входит ли первая буква строки в нее еще раз");
            Console.WriteLine("===============================================================\n");

            try
            {
                // Ввод текста от пользователя
                Console.Write("Введите текст: ");
                string text = GetTextFromUser();

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Вы ввели пустую строку.");
                    return;
                }

                // Получаем первую букву
                char firstLetter = GetFirstLetter(text);

                // Проверяем, входит ли первая буква в строку еще раз
                bool isFirstLetterRepeated = CheckFirstLetterRepeated(text, firstLetter);

                // Выводим результат
                DisplayResults(text, firstLetter, isFirstLetterRepeated);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static string GetTextFromUser()
        {
            string input = Console.ReadLine();
            return input ?? ""; // Возвращаем пустую строку если null
        }

        static char GetFirstLetter(string text)
        {
            // Находим первую букву (игнорируем пробелы и другие символы)
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    return char.ToLower(c); // Приводим к нижнему регистру для регистронезависимой проверки
                }
            }

            throw new InvalidOperationException("В тексте нет букв.");
        }

        static bool CheckFirstLetterRepeated(string text, char firstLetter)
        {
            int count = 0;

            // Считаем, сколько раз первая буква встречается в тексте
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }

            // Если буква встречается 2 и более раз, значит она входит еще раз
            return count >= 2;
        }

        static void DisplayResults(string text, char firstLetter, bool isRepeated)
        {
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("               РЕЗУЛЬТАТЫ");
            Console.WriteLine("═══════════════════════════════════════════");

            Console.WriteLine($"Введенный текст: \"{text}\"");
            Console.WriteLine($"Первая буква: '{firstLetter}' (регистронезависимо)");

            Console.WriteLine($"\nАнализ текста:");

            // Подсчитываем все вхождения первой буквы
            int totalOccurrences = CountOccurrences(text, firstLetter);
            Console.WriteLine($"  Буква '{firstLetter}' встречается в тексте: {totalOccurrences} раз(а)");

            // Находим позиции вхождения
            int[] positions = FindLetterPositions(text, firstLetter);
            Console.WriteLine($"  Позиции вхождения: {string.Join(", ", positions)}");

            Console.WriteLine($"\nВывод:");
            if (isRepeated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  ✓ Первая буква '{firstLetter}' входит в текст еще раз");
                Console.ResetColor();

                // Показываем где именно
                if (positions.Length > 1)
                {
                    Console.WriteLine($"  Буква найдена на позициях: {positions[0] + 1} (первое вхождение)");
                    for (int i = 1; i < positions.Length; i++)
                    {
                        Console.WriteLine($"                      и {positions[i] + 1}");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  ✗ Первая буква '{firstLetter}' не входит в текст еще раз");
                Console.ResetColor();
                Console.WriteLine($"  Она встречается только один раз (на позиции {positions[0] + 1})");
            }

            Console.WriteLine("═══════════════════════════════════════════");
        }

        static int CountOccurrences(string text, char letter)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == letter)
                {
                    count++;
                }
            }
            return count;
        }

        static int[] FindLetterPositions(string text, char letter)
        {
            System.Collections.Generic.List<int> positions = new System.Collections.Generic.List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.ToLower(text[i]) == letter)
                {
                    positions.Add(i);
                }
            }

            return positions.ToArray();
        }
    }
}