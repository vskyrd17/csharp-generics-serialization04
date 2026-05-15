
using GenericLabLib;
using System;
using System.Linq;

namespace GenericLabApp
{
    public static class TestTask1_7
    {
        public static void RunTest()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.7: Створення гнучкого масиву (Додатково)");
            Console.WriteLine("==============================================");

            Task1_7_FlexibleArray<string> a = new Task1_7_FlexibleArray<string>();

            // Початковий стан
            Console.WriteLine($"Початковий стан: {a}");

            // Запис, що розширює масив до індексу 4
            a[4] = "HPI";
            Console.WriteLine($"Після a[4] = 'HPI': {a}");

            // Звернення читання до відсутнього елементу (повертає null, не розширює)
            string val = a[6];
            Console.WriteLine($"a[6] (читання): '{val}'. Масив не змінився.");

            // Запис, що розширює масив ще більше
            a[7] = "C#";
            Console.WriteLine($"Після a[7] = 'C#': {a}");

            Console.Write("Обхід foreach (елементи): ");
            foreach (var x in a)
            {
                Console.Write($"'{x}' ");
            }
            Console.WriteLine();
        }
    }
}