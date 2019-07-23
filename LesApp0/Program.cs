using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        /// <summary>
        /// Делегат для арифметичних операцій
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate double Del(double a, double b);

        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа
            Random rnd = new Random();

            // створення випадкових змінних
            double a = rnd.Next(-9, 10),
                b = rnd.Next(-9, 10);

            Console.WriteLine("\n\tЗадані випадкові числа:");
            Console.WriteLine($"\tA = {a:N0};\n\tB = {b:N0};\n");

            Console.WriteLine(new string('-',80));

            #region Якщо є час друкувати
#if false
            Calculator.Add(a, b);
            Console.WriteLine(Calculator.ToString());

            Calculator.Sub(a, b);
            Console.WriteLine(Calculator.ToString());

            Calculator.Mul(a, b);
            Console.WriteLine(Calculator.ToString());

            Calculator.Div(a, b);
            Console.WriteLine(Calculator.ToString()); 
#endif
            #endregion

            #region Для ну ... дуже лінивих
#if false
            // AO - арифметичні операції
            Del[] AO = new Del[4]
            {
                Calculator.Add,
                Calculator.Sub,
                Calculator.Mul,
                Calculator.Div
            };

            // Вивід результатів
            foreach (var i in AO)
            {
                i(a, b);
                Console.WriteLine(Calculator.ToString());
            } 
#endif
            #endregion

            #region Оптимізований варіант
            // хоча, у вище приведеному методі виконується подвійний розрахунок,
            // тому можна поптимізувати програму

            // створюємо масив операцій
            var masAO = Enum.GetValues(typeof(Calculator.Operations))
                .Cast<Calculator.Operations>().ToArray();

            foreach (var i in masAO)
            {
                // заносимо дані
                Calculator.Save(a, b);
                // кажемо, що начебто була уже була якась операція
                Calculator.Operation = i;
                // виводимо результат
                Console.WriteLine(Calculator.ToString());
            } 
            #endregion

            Console.WriteLine("\n" + new string('-', 80));

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
