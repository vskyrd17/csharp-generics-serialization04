
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericLabApp
{
    public static class TestTask1_5
    {
        public static void RunTest()
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
    }
}