using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Reports.ViewModels
{
    public class ThesesCompleteWithMarkItemViewModel
    {
        public int ThesesUserEntryId { get; set; }
        public string ThesesTitle { get; set; }
        public string ThesesType { get; set; }
        public string StudentName { get; set; }
        public string StudentFacultyNumber { get; set; }
        public string SubjectName { get; set; }
        public decimal MarkResult { get; set; }
    }
}
