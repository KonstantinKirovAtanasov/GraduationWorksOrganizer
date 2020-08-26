using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за помощно съобшение
    /// </summary>
    public class HelpMessage
    {
        /// <summary>Ключ</summary>
        public string Key { get; set; }

        /// <summary>Заглавие</summary>
        public string Title { get; set; }

        /// <summary> Текст </summary>
        public string Content { get; set; }
    }
}
