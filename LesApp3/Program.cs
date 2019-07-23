using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення масиву даних
            Masiv array = new Masiv();

            // випадкові числа
            Random rnd = new Random();

            // випадкова величина масиву
            int lenhth = rnd.Next(10, 28);

            // заповнення випадковими даними
            for (int i = 0; i < lenhth; i++)
            {
                array.Add(rnd.Next(-9, 10));
            }

            // Вивід сформованих даних
            Console.WriteLine("\n\tСформований ряд чисел:\n");
            Console.WriteLine("\t" + array.ToString());

            // сортування
            array = array.OrderUp();

            // Вивід сформованих даних
            Console.WriteLine("\n\tВідсортовані дані за зростанням:\n");
            Console.WriteLine("\t" + array.ToString());

            // сортування
            array = array.OrderDown();

            // Вивід сформованих даних
            Console.WriteLine("\n\tВідсортовані дані за спаданням:\n");
            Console.WriteLine("\t" + array.ToString());

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
