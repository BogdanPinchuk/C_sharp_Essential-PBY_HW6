using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// якась умова "корява"
// 005_Delegation ??? там ні слова про книжку
// _005_Book - це щось найбільш близьке до правди,
// але всерівно нічого незрозуміло, і де шукати якщо інформації немає?
// в умовы не сказано, як саме має відбуватися пошук,
// тому можна скористатися вбудованими функціями

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // припустимо, що користувач ввів для пошуку наступний вираз
            // а виразу такого немає, тобто спочатку помилився
            string s = "Meneg";

            // робимо пошук
            FindAndReplaceManager.FindNext(s);

            Console.WriteLine("\n" + new string('-', 80));

            // потім він скорегував результат
            s = "Com";

            // робимо пошук
            FindAndReplaceManager.FindNext(s);

            // delay
            Console.ReadKey(true);
        }
    }
}
