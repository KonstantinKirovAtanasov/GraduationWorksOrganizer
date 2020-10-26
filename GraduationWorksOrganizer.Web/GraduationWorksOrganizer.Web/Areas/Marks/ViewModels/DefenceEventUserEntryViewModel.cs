using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.Marks.ViewModels
{
    public class DefenceEventUserEntryViewModel
    {
        public int UserEntryId { get; set; }

        public string StudentName { get; set; }

        public string FacultyNumber { get; set; }

        public string SpecialtyName { get; set; }

        public int? DefenceEventId { get; set; }

        #region ThesesItems

        public string ThesesName { get; set; }

        public string Type { get; set; }

        public decimal Points { get; set; }

        public decimal Mark { get; set; }

        public IEnumerable<InnerRequermentViewwModel> Requerments { get; set; }

        #endregion
    }

    public class InnerRequermentViewwModel
    {
        public int Id { get; set; }

        public decimal? MaxPoints { get; set; }

        public decimal MarkPoints { get; set; }

        public string Description { get; set; }
    }
}
