using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Интернет медиа типове
    /// </summary>
    public class MimeType : IDatabaseEntity
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Интернет медиа тип
        /// </summary>
        public string MIMEType { get; set; }

        /// <summary>
        /// Extention на файла
        /// </summary>
        public string FileExtention { get; set; }
    }
}
