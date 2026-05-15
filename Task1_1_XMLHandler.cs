
using System;
using System.IO;
using System.Xml.Serialization;

namespace GenericLabLib
{
    public static class Task1_1_XMLHandler
    {
        // Клас Bookshelf тепер неузагальнений, тому T повинна бути Bookshelf
        public static void SerializeToXml<T>(T obj, string fileName) where T : class
        {
            // ... (цей код має бути узагальненим, але він викликається з Bookshelf)
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, obj);
            }
        }

        public static T DeserializeFromXml<T>(string fileName) where T : class
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                object? data = deserializer.Deserialize(fs);
                return (T)data!;
            }
        }
    }
}