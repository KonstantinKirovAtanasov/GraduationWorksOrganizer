using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за помощно съобшение
    /// </summary>
    public class HelpMessage : IDatabaseEntity
    {
        /// <summary> Ид </summary>
        public int Id { get; set; }

        /// <summary> ключ </summary>
        public string Key { get; set; }

        /// <summary>Заглавие</summary>
        public string Title { get; set; }

        /// <summary> Текст </summary>
        public string Content { get; set; }
    }
}
