
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericLabApp
{
    public static class TestTask1_4
    {
        public static void RunTest(object program)
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
                    Console.WriteLine($"Некоректне введення. Використовуємо 10 елементів.");
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
                Program.ShowException(ex);
            }
        }
    }
}