
using GenericLabLib;
using System;

namespace GenericLabApp
{
    public static class TestTask1_6
    {
        public static void RunTest()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.6: Використання типу dynamic (Додатково)");
            Console.WriteLine("==============================================");

            try
            {
                // 1. Тестування з double
                dynamic[] doubles = { 1.0, 2.0, 3.0, 4.0 };
                Console.WriteLine($"Масив double: {string.Join(", ", doubles)}");
                Console.WriteLine($"Сума: {Task1_6_DynamicUtils.GetSum(doubles)}");
                Console.WriteLine($"Середнє: {Task1_6_DynamicUtils.GetAverage(doubles)}");

                // 2. Тестування з Fraction (потрібне перевантаження операторів у класі Fraction)
                dynamic[] fractions =
                {
                    new Fraction(1, 2),
                    new Fraction(1, 4),
                    new Fraction(1, 4)
                };
                Console.WriteLine($"Масив дробів: {string.Join(", ", fractions)}");

                Console.WriteLine($"Сума: {Task1_6_DynamicUtils.GetSum(fractions)}"); // 1/2 + 1/4 + 1/4 = 1/1
                Console.WriteLine($"Середнє: {Task1_6_DynamicUtils.GetAverage(fractions)}"); // 1/3 (1 / 3)
            }
            catch (Exception ex)
            {
                Program.ShowException(ex);
            }
        }
    }
}