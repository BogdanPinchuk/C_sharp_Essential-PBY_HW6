using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// аналогічна ситуація із попереднім завданням

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Створена книжка
            Book book = new Book();

            // внесення нотатки в книжку
            book.Note.Add("Це список файлових менеджерів для операційної системи Microsoft Windows.");

            // вивід нотатки в консоль
            Console.WriteLine("\n\tВивід нотатки в консоль:\n\t");
            Console.WriteLine("\t" + book.Note[0]);

            // delay
            Console.ReadKey(true);
        }
    }
}
