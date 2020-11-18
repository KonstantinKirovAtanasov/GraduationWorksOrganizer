using System;

namespace GraduationWorksOrganizer.Web.Areas.Reports.ViewModels
{
    /// <summary>
    /// Вю модел за показване на темите които са завършени с оценка
    /// </summary>
    public class PreviewArchiveTheses
    {
        public int UserEntryId { get; set; }

        public decimal MarkResult { get; set; }

        public DateTime MarkDate { get; set; }

        public string ThesesTitle { get; set; }

        public string ThesesType { get; set; }

        public string SubjectName { get; set; }

        public string CreatorScienceDegree { get; set; }

        public string CreatorName { get; set; }

        public string ReviewerScienceDegree { get; set; }

        public string ReviewerName { get; set; }
    }
}
