using System;

namespace GraduationWorksOrganizer.Web.Areas.Reports.ViewModels
{
    public class ThesesInProgresViewModel
    {
        public int ThesesUserEntryId { get; set; }
        public string ThesesTitle { get; set; }
        public string ThesesType { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string StudentFacultyNumber { get; set; }
        public decimal MaxPoints { get; set; }
        public DateTime ThesesCreationDate { get; set; }
        public DateTime ProgressStart { get; set; }
        public DateTime LastUpdate { get; set; }
        public Common.Enums.ThesisUserEntryState State { get; set; }
    }
}
