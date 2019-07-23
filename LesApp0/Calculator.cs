using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Калькуляторі
    /// </summary>
    static class Calculator
    {
        /// <summary>
        /// Наявні операції
        /// </summary>
        public enum Operations
        {
            /// <summary>
            /// Додавання
            /// </summary>
            Add,
            /// <summary>
            /// Віднімання
            /// </summary>
            Sub,
            /// <summary>
            /// Множення
            /// </summary>
            Mul,
            /// <summary>
            /// Ділення
            /// </summary>
            Div
        }
        /// <summary>
        /// Яка остання операція була зроблена
        /// </summary>
        public static Operations Operation { get; set; }
        /// <summary>
        /// Перша змінна
        /// </summary>
        private static double A { get; set; }
        /// <summary>
        /// Друга змінна
        /// </summary>
        private static double B { get; set; }

        /// <summary>
        /// Сума чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Add(double a, double b)
        {
            // збереження даних
            Save(a, b);

            // записуємо операцію
            Operation = Operations.Add;

            return A + B;
        }
        /// <summary>
        /// Різниця чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Sub(double a, double b)
        {
            // збереження даних
            Save(a, b);

            // записуємо операцію
            Operation = Operations.Sub;
            return A - B;
        }
        /// <summary>
        /// Добуток чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Mul(double a, double b)
        {
            // збереження даних
            Save(a, b);

            // записуємо операцію
            Operation = Operations.Mul;
            return A * B;
        }
        /// <summary>
        /// Частка чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double Div(double a, double b)
        {
            // збереження даних
            Save(a, b);

            // записуємо операцію
            Operation = Operations.Div;

            // перевірка на 0
            double temp = default;

            // врахування виключень
            if (A == 0 && B == 0)
            {
                temp = double.NaN;
            }
            else if (A > 0 && B == 0)
            {
                temp = double.PositiveInfinity;
            }
            else if (A < 0 && B == 0)
            {
                temp = double.NegativeInfinity;
            }
            else
            {
                temp = A / B;
            }

            return temp;
        }

        /// <summary>
        /// Збереження змынних для подальшого виведення
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Save(double a, double b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Виведення результату
        /// </summary>
        /// <returns></returns>
        public static new string ToString()
        {
            string s = "\n\t";

            switch (Operation)
            {
                case Operations.Add:
                    s += $"{A} + {B} = {Add(A, B):G3}";
                    break;
                case Operations.Sub:
                    s += $"{A} - {B} = {Sub(A, B):G3}";
                    break;
                case Operations.Mul:
                    s += $"{A} * {B} = {Mul(A, B):G3}";
                    break;
                case Operations.Div:
                    s += $"{A} / {B} = {Div(A, B):G3}";
                    break;
            }
            
            return s;
        }

    }
}
