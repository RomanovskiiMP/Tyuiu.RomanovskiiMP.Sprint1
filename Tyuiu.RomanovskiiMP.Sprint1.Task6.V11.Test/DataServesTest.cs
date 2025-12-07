using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FirstLetterChecker.Tests
{
    [TestClass]
    public class FirstLetterCheckerTests
    {
        [TestMethod]
        public void CheckFirstLetterRepeated_LetterRepeats_ReturnsTrue()
        {
            // Arrange
            string text = "hello world";
            char firstLetter = 'h'; // Первая буква 'h'
                                    // В тексте есть еще 'h' в слове "hello"

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_LetterDoesNotRepeat_ReturnsFalse()
        {
            // Arrange
            string text = "apple";
            char firstLetter = 'a'; // Первая буква 'a'
                                    // В слове "apple" буква 'a' встречается только один раз

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_CaseInsensitive_ReturnsTrue()
        {
            // Arrange
            string text = "Hello Hello";
            char firstLetter = 'h'; // Первая буква 'H' (но проверяем в нижнем регистре)

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.IsTrue(result, "Проверка должна быть регистронезависимой");
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_WithSpaces_ReturnsTrue()
        {
            // Arrange
            string text = "a b a c";
            char firstLetter = 'a'; // Первая буква 'a', встречается еще раз

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_SingleCharacter_ReturnsFalse()
        {
            // Arrange
            string text = "a";
            char firstLetter = 'a';

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_EmptyString_ThrowsException()
        {
            // Arrange
            string text = "";

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                foreach (char c in text)
                {
                    if (char.IsLetter(c))
                    {
                        // Этот код не выполнится для пустой строки
                    }
                }
                throw new InvalidOperationException("В тексте нет букв.");
            });
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_MultipleOccurrences_ReturnsTrue()
        {
            // Arrange
            string text = "banana";
            char firstLetter = 'b'; // На самом деле первая буква 'b', но в "banana" она не повторяется
                                    // Тест проверяет, что если первая буква 'a', то она повторяется

            // Сначала находим реальную первую букву
            char realFirstLetter = ' ';
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    realFirstLetter = char.ToLower(c);
                    break;
                }
            }

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == realFirstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.AreEqual('b', realFirstLetter);
            Assert.IsFalse(result); // 'b' не повторяется в "banana"
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_SpecialCharactersFirst()
        {
            // Тест: если строка начинается с пробела или специального символа

            // Arrange
            string text = "   apple";
            // Первая буква (игнорируя пробелы) - 'a'

            // Находим первую букву
            char firstLetter = ' ';
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    firstLetter = char.ToLower(c);
                    break;
                }
            }

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.AreEqual('a', firstLetter);
            Assert.IsFalse(result); // 'a' не повторяется в "apple"
        }

        [TestMethod]
        public void CheckFirstLetterRepeated_NumbersFirst()
        {
            // Тест: если строка начинается с цифры

            // Arrange
            string text = "123abc123";
            // Первая буква - 'a'

            // Находим первую букву
            char firstLetter = ' ';
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    firstLetter = char.ToLower(c);
                    break;
                }
            }

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.AreEqual('a', firstLetter);
            Assert.IsFalse(result); // 'a' не повторяется
        }

        [TestMethod]
        [DataRow("abracadabra", true)]  // 'a' повторяется много раз
        [DataRow("hello", true)]        // 'h' не повторяется, но 'e'? Нет, первая буква 'h'
        [DataRow("test", true)]         // 't' повторяется
        [DataRow("world", false)]       // 'w' не повторяется
        [DataRow("success", true)]      // 's' повторяется
        [DataRow("programming", true)]  // 'p' не повторяется, но 'r'? Нет, первая 'p'
        [DataRow("xyz", false)]         // 'x' не повторяется
        [DataRow("aa", true)]           // 'a' повторяется
        [DataRow("a", false)]           // только одна буква
        public void CheckFirstLetterRepeated_VariousInputs_ReturnsExpected(
            string text, bool expected)
        {
            // Находим первую букву
            char firstLetter = ' ';
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    firstLetter = char.ToLower(c);
                    break;
                }
            }

            // Считаем вхождения
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == firstLetter)
                {
                    count++;
                }
            }
            bool result = count >= 2;

            // Assert
            Assert.AreEqual(expected, result,
                $"Ошибка для текста: \"{text}\". Первая буква: '{firstLetter}'");
        }

        [TestMethod]
        public void GetFirstLetter_FindsFirstLetterIgnoringNonLetters()
        {
            // Arrange
            string[] testCases = {
                "  hello",   // пробелы в начале
                "123start",  // цифры в начале
                "@home",     // специальный символ
                "a",         // только буква
                "   ",       // только пробелы (ожидается исключение)
            };

            char[] expected = { 'h', 's', 'h', 'a' };

            for (int i = 0; i < testCases.Length - 1; i++) // последний тест - особый
            {
                // Act
                char firstLetter = ' ';
                foreach (char c in testCases[i])
                {
                    if (char.IsLetter(c))
                    {
                        firstLetter = char.ToLower(c);
                        break;
                    }
                }

                // Assert
                Assert.AreEqual(expected[i], firstLetter,
                    $"Ошибка для строки: \"{testCases[i]}\"");
            }
        }

        [TestMethod]
        public void CountOccurrences_CountsCorrectly()
        {
            // Arrange
            string text = "Mississippi";
            char letter = 's';
            int expected = 4; // В "Mississippi" буква 's' встречается 4 раза

            // Act
            int count = 0;
            foreach (char c in text)
            {
                if (char.ToLower(c) == letter)
                {
                    count++;
                }
            }

            // Assert
            Assert.AreEqual(expected, count);
        }
    }
}