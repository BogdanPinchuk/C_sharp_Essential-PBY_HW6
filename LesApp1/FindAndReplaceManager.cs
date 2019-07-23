using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    /// <summary>
    /// Знайти і замінити менеджера
    /// </summary>
    static class FindAndReplaceManager
    {
        // Підключаємо базу даних
        private static Book book = new Book();
        /// <summary>
        /// Правор, на те чи пошук дав якісь результати
        /// </summary>
        private static bool Find { get; set; } = false;

        /// <summary>
        /// Шукати далі
        /// </summary>
        /// <param name="str"></param>
        public static void FindNext(string str)
        {
            Console.WriteLine("\n\tПошук по введеному результату: " + str + "\n");

            // переглядаємо книгу даних
            for (int i = 0; i < book.Length; i++)
            {
                // якщо співпадіння є то виводимо на екран
                if (book[i].ToLower().Contains(str.ToLower()))
                {
                    Console.WriteLine("\t- " + book[i]);
                    Find |= true;
                }
            }

            // якщо результів не найшлось, виводимо сповіщення
            if (!Find)
            {
                Console.WriteLine("\n\tПошук не дав результатів.");
            }
        }
    }
}
