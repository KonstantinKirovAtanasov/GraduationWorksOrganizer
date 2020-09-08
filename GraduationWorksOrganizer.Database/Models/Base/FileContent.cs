using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models.Base
{
    /// <summary>
    /// Клас за модел за файл
    /// </summary>
    public class FileContent : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public byte[] Content { get; set; }
    }
}
