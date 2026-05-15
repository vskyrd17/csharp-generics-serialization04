
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericLabLib
{
    public class Task1_3_CustomRangeArray<T> : IEnumerable<T>
    {
        private readonly List<T> _data;

        public int From { get; }
        public int To => From + _data.Count - 1;

        // Конструктор з From та To
        public Task1_3_CustomRangeArray(int from, int to)
        {
            if (from > to)
                throw new ArgumentException("From не може бути більшим за To.");

            From = from;
            _data = new List<T>(to - from + 1);
            for (int i = 0; i < to - from + 1; i++) _data.Add(default(T)!);
        }

        // Конструктор з From та params T[]
        public Task1_3_CustomRangeArray(int from, params T[] initialData)
        {
            From = from;
            _data = new List<T>(initialData);
        }

        // Індексатор
        public T this[int index]
        {
            get
            {
                if (index < From || index > To)
                    throw new IndexOutOfRangeException($"Індекс {index} виходить за межі [{From}, {To}].");
                return _data[index - From];
            }
            set
            {
                if (index < From || index > To)
                    throw new IndexOutOfRangeException($"Індекс {index} виходить за межі [{From}, {To}].");
                _data[index - From] = value;
            }
        }

        // Метод додавання
        public void Add(T item)
        {
            _data.Add(item);
        }

        // Метод видалення останнього елемента
        public void RemoveLast()
        {
            if (_data.Count > 0)
            {
                _data.RemoveAt(_data.Count - 1);
            }
        }

        // Ітератор для foreach
        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Перевантажений ToString()
        public override string ToString() => $"Range: [{From}..{To}]. Values: [{string.Join(", ", _data)}]";
    }
}