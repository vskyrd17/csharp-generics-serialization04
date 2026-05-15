using GenericLabLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenericLabApp
{
    class Program
    {
        // -------------------------------------------------------------
        // Допоміжний метод для виведення винятків
        internal static void ShowException(Exception ex)
        {
            Console.WriteLine("------------Виняток:------------");
            Console.WriteLine(ex.GetType().Name);
            Console.WriteLine("-------------Зміст:-------------");
            Console.WriteLine(ex.Message);
        }

        // -------------------------------------------------------------
        // Task 1.1: Контейнер Bookshelf та XML-серіалізація
        internal static void Test_Task1_1()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.1: Контейнер Bookshelf та XML-серіалізація");
            Console.WriteLine("==============================================");

            try
            {
                // Створення об'єктів (перевірте, що класи Book, Author, Magazine існують у GenericLabLib)
                var book = new Book
                {
                    Title = "Узагальнене програмування",
                    Year = 2024,
                    Authors = new List<Author> { new Author("Ігор", "Сміт") }
                };
                var magazine = new Magazine { Title = "Журнал ІТ", Issue = 5, Year = 2023 };

                var bookshelf = new Bookshelf<object>("ХПІ 121-Спец");
                bookshelf.AddItem(book);
                bookshelf.AddItem(magazine);

                Console.WriteLine(bookshelf);

                string filename = "bookshelf.xml";

                Task1_1_XMLHandler.SerializeToXml(bookshelf, filename);
                Console.WriteLine($"Успішна серіалізація у файл: {Path.GetFullPath(filename)}");

                var loadedShelf = Task1_1_XMLHandler.DeserializeFromXml<Bookshelf<object>>(filename);
                Console.WriteLine($"Успішна десеріалізація. Завантажено полицю: {loadedShelf.ShelfName}");

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // -------------------------------------------------------------
        // Task 1.2: Бібліотека узагальнених функцій
        internal static void Test_Task1_2()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.2: Тестування GenericUtils");
            Console.WriteLine("==============================================");

            List<int> intList = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80 };
            Console.WriteLine($"Початковий список: {string.Join(", ", intList)}");

            Task1_2_GenericUtils.SwapAdjacentPairs(intList);
            Console.WriteLine($"Обмін пар сусідів: {string.Join(", ", intList)}");

            Task1_2_GenericUtils.SwapGroups(intList, 0, 4, 2);
            Console.WriteLine($"Обмін груп (0..1) і (4..5): {string.Join(", ", intList)}");
        }

        // -------------------------------------------------------------
        // Task 1.3: Створення власного контейнера
        internal static void Test_Task1_3()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.3: Тестування CustomRangeArray");
            Console.WriteLine("==============================================");

            Task1_3_CustomRangeArray<string> names = new(5, "A", "B", "C");
            Console.WriteLine($"Масив [5..7]: {names}");

            names.Add("D");
            Console.WriteLine($"Після Add (D): {names}");

            names[7] = "X";
            names.RemoveLast();
            Console.WriteLine($"Після RemoveLast: {names}");
        }

        // -------------------------------------------------------------
        // Task 1.4: Робота з множиною (ІНТЕРАКТИВНИЙ ВВІД)
        internal static void Test_Task1_4()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("       1.4: Робота з множиною HashSet<int>");
            Console.WriteLine("==============================================");

            try
            {
                Console.Write("Введіть необхідну кількість унікальних елементів: ");
                if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
                {
                    count = 10;
                    Console.WriteLine($"Некоректне введення. Використовуємо {count} елементів.");
                }

                Console.Write("Введіть мінімальне значення діапазону: ");
                if (!int.TryParse(Console.ReadLine(), out int minVal)) minVal = 1;

                Console.Write("Введіть максимальне значення діапазону: ");
                if (!int.TryParse(Console.ReadLine(), out int maxVal) || maxVal <= minVal) maxVal = minVal + 20;

                Random random = new Random();
                SortedSet<int> set = new SortedSet<int>();

                int attempts = 0;
                while (set.Count < count && attempts < 1000)
                {
                    set.Add(random.Next(minVal, maxVal + 1));
                    attempts++;
                }

                Console.WriteLine($"\nСформована множина ({set.Count} унікальних елементів у діапазоні [{minVal}..{maxVal}]):");
                Console.WriteLine($"Елементи: {{{string.Join(", ", set)}}}");
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // -------------------------------------------------------------
        // Task 1.5: Асоціативний масив (ІНТЕРАКТИВНИЙ ВВІД)
        internal static void Test_Task1_5()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("     1.5: Підрахунок літер у реченні");
            Console.WriteLine("==============================================");

            Console.Write("Введіть речення для аналізу літер: ");
            string sentence = Console.ReadLine()?.ToLower() ?? "";

            SortedDictionary<char, int> letterCounts = new SortedDictionary<char, int>();

            foreach (char c in sentence)
            {
                if (char.IsLetter(c))
                {
                    letterCounts[c] = letterCounts.ContainsKey(c) ? letterCounts[c] + 1 : 1;
                }
            }

            Console.WriteLine("\nРезультат (Літера: Кількість входжень), відсортований за збільшенням літери:");
            foreach (var pair in letterCounts)
            {
                Console.WriteLine($"'{pair.Key}': {pair.Value}");
            }
        }

        // -------------------------------------------------------------
        // Task 1.6: Використання типу dynamic
        internal static void Test_Task1_6()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.6: Використання типу dynamic");
            Console.WriteLine("==============================================");
            try
            {
                dynamic[] doubles = { 1.0, 2.0, 3.0, 4.0 };
                Console.WriteLine($"Масив double: {string.Join(", ", doubles)}");
                Console.WriteLine($"Середнє: {Task1_6_DynamicUtils.GetAverage(doubles)}");
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        // -------------------------------------------------------------
        // Task 1.7: Створення "гнучкого" масиву
        internal static void Test_Task1_7()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.7: Створення гнучкого масиву");
            Console.WriteLine("==============================================");

            Task1_7_FlexibleArray<int> a = new Task1_7_FlexibleArray<int>();

            Console.WriteLine($"Початковий стан: {a}");
            a[4] = 100;
            Console.WriteLine($"Після a[4] = 100: {a}");

            int val = a[6];
            Console.WriteLine($"a[6] (читання): {val}. Масив не змінився.");
        }


        // -------------------------------------------------------------
        // ГОЛОВНА ФУНКЦІЯ MAIN
        static void Main(string[] args)
        {
            // Встановлення кодування для коректного відображення кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("----------- ПОЧАТОК ЛАБОРАТОРНОЇ РОБОТИ 4 -----------");

            // Виклики всіх тестів
            Test_Task1_1();
            Test_Task1_4();
            Test_Task1_5();
            Test_Task1_2();
            Test_Task1_3();
            Test_Task1_6();
            Test_Task1_7();

            Console.WriteLine("\n----------- КІНЕЦЬ ЛАБОРАТОРНОЇ РОБОТИ 4 -----------");

            Console.Write("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}