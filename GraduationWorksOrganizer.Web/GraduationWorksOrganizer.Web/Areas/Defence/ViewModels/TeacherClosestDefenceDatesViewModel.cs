using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.Defence.ViewModels
{
    public class TeacherClosestDefenceDatesViewModel
    {
        public string TeacherId { get; set; }

        public string TeacherName { get; set; }

        public IEnumerable<InnerDefenceDate> DefenceDates { get; set; }
    }

    public class InnerDefenceDate
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
