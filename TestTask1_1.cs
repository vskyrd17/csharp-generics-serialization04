
using GenericLabLib;
using System;
using System.IO;
using System.Collections.Generic;

namespace GenericLabApp
{
    public static class TestTask1_1
    {
        public static void RunTest()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    1.1: Контейнер Bookshelf та XML-серіалізація");
            Console.WriteLine("==============================================");

            try
            {
                var book = new Book
                {
                    Title = "Узагальнене програмування",
                    Year = 2024,
                    Authors = new List<Author> { new Author("Ігор", "Сміт") }
                };
                var magazine = new Magazine { Title = "Журнал ІТ", Issue = 5, Year = 2023 };
                var bookshelf = new Bookshelf<object>("ХПІ 121-Спец");
                bookshelf.AddItem(book);
                bookshelf.AddItem(magazine);

                Console.WriteLine(bookshelf);

                string filename = "bookshelf.xml";

                Task1_1_XMLHandler.SerializeToXml(bookshelf, filename);
                Console.WriteLine($"Успішна серіалізація у файл: {Path.GetFullPath(filename)}");

                var loadedShelf = Task1_1_XMLHandler.DeserializeFromXml<Bookshelf<object>>(filename);
                Console.WriteLine($"Успішна десеріалізація. Завантажено полицю: {loadedShelf.ShelfName}");

                Console.WriteLine($"\nТест: Книга 'Узагальнене програмування' має хеш-код: {book.GetHashCode()}");

            }
            catch (Exception ex)
            {
                Program.ShowException(ex);
            }
        }
    }
}