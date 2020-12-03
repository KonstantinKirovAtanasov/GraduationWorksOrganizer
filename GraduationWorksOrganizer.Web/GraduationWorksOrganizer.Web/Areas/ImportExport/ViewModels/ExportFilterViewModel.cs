using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.ImportExport.ViewModels
{
    public class ExportFilterViewModel
    {
        public int SpecialtyId { get; set; }
        public int DefenceDateId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string StudentId { get; set; }
    }
}
