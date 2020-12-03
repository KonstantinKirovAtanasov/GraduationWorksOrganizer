using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.ImportExport.ViewModels
{
    public class ExportMarkViewModel
    {
        public string StudentName { get; set; }
        public string FacultyNumber { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public decimal Mark { get; set; }
        public decimal Points { get; set; }
        public decimal MaxPoints { get; set; }
        public string TeacherName { get; set; }
        public string ScienceDegree { get; set; }
    }
}
