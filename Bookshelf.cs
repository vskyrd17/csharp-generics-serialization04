
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace GenericLabLib
{
    
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Magazine))]
    public class Bookshelf<T> : IEnumerable<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();

        [XmlAttribute]
        public string ShelfName { get; set; } = "Unknown Shelf";

        public Bookshelf() { }
        public Bookshelf(string name) => ShelfName = name;

        public void AddItem(T item) => Items.Add(item);

        public override string ToString()
        {
            return $"--- Полиця: {ShelfName} ({Items.Count} одиниць) ---";
        }

        // Додаємо Equals() та GetHashCode() для Bookshelf
        public override bool Equals(object? obj)
        {
            return obj is Bookshelf<T> bookshelf &&
                   ShelfName == bookshelf.ShelfName &&
                   Items.SequenceEqual(bookshelf.Items);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ShelfName, Items);
        }

        // Реалізація для foreach
        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}