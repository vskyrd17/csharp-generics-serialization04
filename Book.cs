
using System.Collections.Generic;
using System.Linq; 
using System.Xml.Serialization;

namespace GenericLabLib
{
    public class Book : Publication
    {
        // Використовуємо List замість масиву (вимога 1.1)
        public List<Author> Authors { get; set; } = new List<Author>();

        // Обов'язково для XML-серіалізації
        public Book() { }

        public override string ToString() => $"Книга: '{Title}' ({Year}). Автори: {string.Join(", ", Authors)}";

        // Перевизначення Equals() (включаючи порівняння списку авторів)
        public override bool Equals(object? obj)
        {
            // Перевіряємо базовий клас, потім порівнюємо списки авторів
            return obj is Book book &&
                   base.Equals(book) &&
                   Authors.SequenceEqual(book.Authors); // Використовуємо Linq
        }

        // Перевизначення GetHashCode()
        public override int GetHashCode()
        {
            // Комбінуємо хеш-код базового класу та списку авторів
            return HashCode.Combine(base.GetHashCode(), Authors);
        }
    }
}