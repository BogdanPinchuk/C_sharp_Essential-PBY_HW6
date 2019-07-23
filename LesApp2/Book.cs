using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// припустимо, що в нас є записна книга менеджерів
// і це не люди, а файлові менеджери
// https://ru.wikipedia.org/wiki/Список_файловых_менеджеров

namespace LesApp2
{
    /// <summary>
    /// Книжка менеджерів
    /// </summary>
    class Book
    {
        /// <summary>
        /// Список файлових менеджерів для операційної системи Microsoft Windows
        /// </summary>
        private string[] array = new string[]
        {
            "A43",
            "Altap Salamander",
            "Directory Opus",
            "Double Commander",
            "EF Commander",
            "FAR Manager",
            "FileCommander",
            "File Navigator",
            "FreeCommander",
            "Frigate",
            "Gyula's Navigator",
            "JExplorer",
            "Just Manager",
            "NexusFile",
            "Nomad.NET",
            "Q-Dir",
            "SpeedCommander",
            "Total Commander",
            "Unreal Commander",
            "ViewFD",
            "xplorer2",
            "MusicSort Platinum",
            "Проводник — файловый менеджер среды"
        };

        /// <summary>
        /// Нотатки користувача до всієї книги в загальному
        /// </summary>
        private Notes note = new Notes();

        /// <summary>
        /// Отримуємо кількість елемнтів масиву
        /// </summary>
        public int Length { get { return array.Length; } }
        public Notes Note
        {
            get { return note; }
        }

        /// <summary>
        /// Індексатор достуру до елемнтів
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (0 <= index && index < Length)
                {
                    return array[index];
                }
                else
                {
                    return "\n\tВихід за межі масиву";
                }
            }
        }

        /// <summary>
        /// Нотатки
        /// </summary>
        public class Notes
        {
            /// <summary>
            /// Нотатки
            /// </summary>
            private string[] notes = new string[4];
            
            /// <summary>
            /// Кількість елементів
            /// </summary>
            public int Count { get; private set; }
            /// <summary>
            /// Ємність масиву
            /// </summary>
            public int Capacity { get { return notes.Length; } }

            /// <summary>
            /// Зміна розмірів масиву
            /// </summary>
            /// <param name="newSize"></param>
            private void Resize(int newSize)
            {
                string[] temp = new string[newSize];
                // перепис даних в новий масив
                for (int i = 0; i < Count; i++)
                {
                    temp[i] = notes[i];
                }

                notes = temp;
            }

            /// <summary>
            /// Додавання елементів
            /// </summary>
            /// <param name="s">нотатка</param>
            public void Add(string s)
            {
                if (Count == Capacity)
                {
                    Resize(Capacity * 2);
                }

                notes[Count] = s;
                Count++;
            }

            public string this[int index]
            {
                get
                {
                    if (0 <= index && index < Count)
                    {
                        return notes[index];
                    }
                    else
                    {
                        return "\n\tВихід за межі масиву";
                    }
                }
                set
                {
                    if (0 <= index && index < Count)
                    {
                        notes[index] = value;
                    }
                    else
                    {
                        Console.WriteLine("\n\tВихід за межі масиву");
                    }
                }
            }
        }
    }
}
