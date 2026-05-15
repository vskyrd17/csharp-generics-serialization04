
using System.Xml.Serialization;

namespace GenericLabLib
{
    // Наслідує базовий клас Publication
    public class Magazine : Publication
    {
        [XmlAttribute]
        public int Volume { get; set; }

        [XmlAttribute]
        public int Issue { get; set; }

        // Обов'язково для XML-серіалізації
        public Magazine() { }

        public override string ToString()
        {
            return $"Журнал: '{Title}' ({Year}). Том: {Volume}, Номер: {Issue}";
        }

        // Перевірте, чи немає класу Magazine в інших файлах (Publication.cs, Book.cs)

       
        public override bool Equals(object? obj)
        {
            return obj is Magazine magazine &&
                   base.Equals(magazine) && // Перевірка полів Title та Year
                   Volume == magazine.Volume &&
                   Issue == magazine.Issue;
        }

       
        public override int GetHashCode()
        {
            // Комбінуємо хеш-код базового класу та власних полів
            return HashCode.Combine(base.GetHashCode(), Volume, Issue);
        }
    }
}