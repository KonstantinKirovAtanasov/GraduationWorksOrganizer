using System;

namespace GraduationWorksOrganizer.Web.Areas.Reports.ViewModels
{
    public class ReportFilterViewModel
    {
        public int SubjectId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string ThesesType { get; set; }
    }
}
