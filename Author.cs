
using System.Xml.Serialization;

namespace GenericLabLib
{
    public class Author
    {
        [XmlAttribute]
        public string Name { get; set; } = "";

        [XmlAttribute]
        public string Surname { get; set; } = "";

        public Author() { }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString() => $"{Name} {Surname}";

        // Перевизначення Equals()
        public override bool Equals(object? obj)
        {
            return obj is Author author &&
                   Name == author.Name &&
                   Surname == author.Surname;
        }

        // Перевизначення GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname);
        }
    }
}