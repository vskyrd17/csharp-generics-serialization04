
using GenericLabLib;
using System;
using System.Linq;

namespace GenericLabApp
{
    public static class TestTask1_3
    {
        public static void RunTest()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.3: Тестування CustomRangeArray");
            Console.WriteLine("==============================================");

            // Створення масиву з від'ємними індексами: [-3..1]
            Task1_3_CustomRangeArray<int> arr = new(-3, 1);

            arr[-3] = 10;
            arr[1] = 99;

            Console.WriteLine($"Масив {arr.From} до {arr.To}: {arr}");

            arr.Add(1000); // Додаємо елемент (індекс 2)
            Console.WriteLine($"Після Add (1000): {arr}");

            arr.RemoveLast();
            Console.WriteLine($"Після RemoveLast: {arr}"); // Індекс 2 видалено

            Console.Write("Обхід foreach: ");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}