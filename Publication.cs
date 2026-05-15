
using System.Xml.Serialization;

namespace GenericLabLib
{
    // Базовий клас для Book та Magazine
    public abstract class Publication
    {
        [XmlAttribute]
        public string Title { get; set; } = "";

        [XmlAttribute]
        public int Year { get; set; }

        // Перевизначення Equals()
        public override bool Equals(object? obj)
        {
            return obj is Publication publication &&
                   Title == publication.Title &&
                   Year == publication.Year;
        }

        // Перевизначення GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Year);
        }
    }
}