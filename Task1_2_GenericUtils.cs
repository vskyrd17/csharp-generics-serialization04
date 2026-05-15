
using System.Collections.Generic;

namespace GenericLabLib
{
    public static class Task1_2_GenericUtils
    {
        private static void Swap<T>(IList<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        // 1. Обмін місцями двох груп елементів
        public static void SwapGroups<T>(IList<T> list, int indexA, int indexB, int length)
        {
            if (indexA < 0 || indexB < 0 || indexA + length > list.Count || indexB + length > list.Count)
                throw new ArgumentOutOfRangeException("Некоректні індекси або довжина груп.");

            for (int i = 0; i < length; i++)
            {
                Swap(list, indexA + i, indexB + i);
            }
        }

        // 2. Обмін місцями усіх пар сусідніх елементів
        public static void SwapAdjacentPairs<T>(IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i += 2)
            {
                Swap(list, i, i + 1);
            }
        }

        // 3. Вставлення у список іншого списку елементів
        public static void InsertRange<T>(List<T> list, int index, IEnumerable<T> elements)
        {
            if (index < 0 || index > list.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Некоректний індекс вставки.");

            list.InsertRange(index, elements);
        }

        // 4. Заміна групи елементів іншим масивом (списком) елементів
        public static void ReplaceRange<T>(List<T> list, int index, int count, IEnumerable<T> replacementElements)
        {
            if (index < 0 || index + count > list.Count)
                throw new ArgumentOutOfRangeException("Некоректині параметри для заміни.");

            list.RemoveRange(index, count);
            list.InsertRange(index, replacementElements);
        }
    }
}