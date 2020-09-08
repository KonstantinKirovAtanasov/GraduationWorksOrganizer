using GraduationWorksOrganizer.Database.Models.Base;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за материали по дад тема
    /// </summary>
    public class ThesisUserEntryFileContent : FileContent
    {
        public string FileName { get; set; }

        /// <summary>
        /// Релация към UserEntry
        /// </summary>
        public ThesesUserEntry UserEntry { get; set; }

        /// <summary>
        /// Ид на UserEntry
        /// </summary>
        public int UserEntryId { get; set; }
    }
}
