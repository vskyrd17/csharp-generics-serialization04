
namespace GenericLabLib
{
    public static class Task1_6_DynamicUtils
    {
        // Отримання суми елементів масиву
        public static dynamic GetSum(dynamic[] arr)
        {
            if (arr.Length == 0) return default(dynamic);

            dynamic sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i]; // Операція буде визначена під час виконання
            }
            return sum;
        }

        // Отримання середнього арифметичного елементів масиву
        public static dynamic GetAverage(dynamic[] arr)
        {
            if (arr.Length == 0) return default(dynamic);

            dynamic sum = GetSum(arr);
            return sum / arr.Length; // Використовує перевантажений оператор /
        }

        // Отримання добутку елементів масиву
        public static dynamic GetProduct(dynamic[] arr)
        {
            if (arr.Length == 0) return default(dynamic);

            dynamic product = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                product *= arr[i]; // Операція буде визначена під час виконання
            }
            return product;
        }
    }
}