using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// припустимо, що в нас є записна книга менеджерів
// і це не люди, а файлові менеджери
// https://ru.wikipedia.org/wiki/Список_файловых_менеджеров

namespace LesApp1
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
        /// Отримуємо кількість елемнтів масиву
        /// </summary>
        public int Length { get { return array.Length; } }

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
    }
}
