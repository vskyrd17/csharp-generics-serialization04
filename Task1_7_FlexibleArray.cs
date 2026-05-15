
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericLabLib
{
    public class Task1_7_FlexibleArray<T> : IEnumerable<T>
    {
        private List<T> _data = new List<T>();

        // Конструктор без параметрів
        public Task1_7_FlexibleArray() { }

        // Індексатор
        public T this[int index]
        {
            get
            {
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
                // Читання: якщо індекс поза межами, повертаємо default, масив не росте
                if (index >= _data.Count) return default(T)!;
                return _data[index];
            }
            set
            {
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

                // Запис: якщо індекс більший, розширюємо масив
                if (index >= _data.Count)
                {
                    while (_data.Count <= index)
                    {
                        _data.Add(default(T)!); // Заповнюємо прогалини
                    }
                }
                _data[index] = value;
            }
        }

        // Властивість, яка повертає індекс останнього елемента
        public int LastIndex => _data.Count - 1;

        // Ітератор та ToString
        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public override string ToString() => $"FlexibleArray (Last Index: {LastIndex}): [{string.Join(", ", _data)}]";
    }
}