using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Marks.ViewModels
{
    public class MarkItemViewModel
    {
        public string SubjectName { get; set; }

        public DateTime Date { get; set; }

        public string ThesesTitle { get; set; }

        public string ThesesType { get; set; }

        public decimal ThesesPoints { get; set; }

        public decimal? MarkPoints { get; set; }

        public string TeacherName { get; set; }

        public string TeacherScienceDegree { get; set; }

        public decimal? MarkValue { get; set; }

        public int? DefenceEventId { get; set; }

        public string PointsPercentage
        {
            get
            {
                if (MarkPoints.HasValue)
                    return (MarkPoints / ThesesPoints).Value.ToString("P", CultureInfo.InvariantCulture);
                return "-";
            }
        }
    }
}
