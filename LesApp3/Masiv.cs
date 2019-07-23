using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    /// <summary>
    /// Масив елементів
    /// </summary>
    class Masiv
    {
        /// <summary>
        /// Вивід в консоль
        /// </summary>
        public enum OutResult
        {
            /// <summary>
            /// В рядок
            /// </summary>
            first,
            /// <summary>
            /// В колонку
            /// </summary>
            second
        }

        /// <summary>
        /// Масив цілих значень
        /// </summary>
        private int[] array = new int[4];

        /// <summary>
        /// Кількість елементів
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity
        {
            get { return array.Length; }
        }

        /// <summary>
        /// Індексатор доступу до елементів
        /// </summary>
        /// <param name="index">індекс елемента</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                    return default;
                }
            }
            set
            {
                try
                {
                    array[index] = value;
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Додавання елемнтів масивом
        /// </summary>
        /// <param name="value">Масив вхідних значень</param>
        public void AddRange(params int[] value)
        {
            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2) 
            #endregion

            // щоб даремно не виконувати лишні операції,
            // то краще перевірити чи щось було передано
            if (value.Length < 1)
            {
                return;
            }

            // зміна розмірів, якщо необхідно
            if (Count + value.Length == Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2)) + 1));
            }
            else if (Count + value.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2))));
            }

            // присвоєння значень
            for (int i = 0; i < value.Length; i++)
            {
                array[Count] = value[i];
                Count++;
            }
        }

        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="num">Необхідна кількість елементів масиву</param>
        private void Resize(int num)
        {
            // новий тимчасовий масив
            int[] mas = new int[num];
            // min, якщо прийдеться обрізати масив
            for (int i = 0; i < Math.Min(array.Length, num); i++)
            {
                mas[i] = array[i];
            }

            array = mas;
        }

        /// <summary>
        /// Сортування по зростанню
        /// </summary>
        /// <returns></returns>
        public Masiv OrderUp()
        {
            // створення масиву
            int[] mas = new int[Count];
            // копіювання масиву
            for (int i = 0; i < Count; i++)
            {
                mas[i] = array[i];
            }

            for (int i = 0; i < Count - 1; i++)
            {
                // припускаємо що елемент на i-му місці - мінімальний
                int min = mas[i];
                // індекс мінімального елемента
                int num = i;

                for (int j = i + 1; j < Count; j++)
                {
                    if (min > mas[j])
                    {
                        min = mas[j];
                        num = j;
                    }
                }

                // міняємо місцями елементи
                int temp = mas[i];
                mas[i] = mas[num];
                mas[num] = temp;
            }

            Masiv res = new Masiv();
            res.AddRange(mas);

            return res;
        }

        /// <summary>
        /// Сортування по спаданню
        /// </summary>
        /// <returns></returns>
        public Masiv OrderDown()
        {
            // тимчасовий масив для копіювання даних і відсортований масив
            Masiv temp = new Masiv(),
                sort = OrderUp();

            // копіювання відсортованих даних з кінця
            for (int i = 0; i < Count; i++)
            {
                temp.Add(sort[Count - i - 1]);
            }

            return temp;
        }

        /// <summary>
        /// Відображення рядка в кольорі
        /// </summary>
        /// <param name="s">рядок</param>
        /// <param name="color">колір</param>
        private static void Show(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Тип виведення масиву в консоль
        /// </summary>
        public OutResult TypeOutResult { get; set; } = OutResult.first;

        /// <summary>
        /// Вивід в консоль
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();

            switch (TypeOutResult)
            {
                case OutResult.first:
                    for (int i = 0; i < Count; i++)
                    {
                        s.Append(array[i] + " ");
                    }
                    break;
                case OutResult.second:
                    for (int i = 0; i < Count; i++)
                    {
                        s.Append($"\n\tArr[{i}] - {array[i]}");
                    }
                    break;
            }

            return s.ToString();
        }

    }
}
