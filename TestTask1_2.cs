
using GenericLabLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericLabApp
{
    public static class TestTask1_2
    {
        public static void RunTest()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.2: Тестування GenericUtils");
            Console.WriteLine("==============================================");

            List<int> intList = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80 };
            Console.WriteLine($"Початковий список: {string.Join(", ", intList)}");

            // 1. Обмін пар сусідів
            Task1_2_GenericUtils.SwapAdjacentPairs(intList);
            Console.WriteLine($"Обмін пар сусідів: {string.Join(", ", intList)}"); // 20, 10, 40, 30, 60, 50, 80, 70

            // 2. Обмін груп
            Task1_2_GenericUtils.SwapGroups(intList, 0, 4, 2);
            Console.WriteLine($"Обмін груп (0..1) і (4..5): {string.Join(", ", intList)}"); // 60, 50, 40, 30, 20, 10, 80, 70

            // 3. Вставка
            Task1_2_GenericUtils.InsertRange(intList, 2, new List<int> { 99 });
            Console.WriteLine($"Вставка 99 на індекс 2: {string.Join(", ", intList)}");

            // 4. Заміна
            Task1_2_GenericUtils.ReplaceRange(intList, 0, 1, new List<int> { 5 });
            Console.WriteLine($"Заміна елемента 0: {string.Join(", ", intList)}");
        }
    }
}