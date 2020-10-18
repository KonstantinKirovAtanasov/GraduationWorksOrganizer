using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.Marks.ViewModels
{
    public class DefenceDateViewModel
    {
        public string Description { get; set; }

        public DateTime FromDate { get; set; }

        public int Id { get; set; }

        public IEnumerable<DefenceEventUserEntryViewModel> DefenceEntries { get; set; }
    }
}
