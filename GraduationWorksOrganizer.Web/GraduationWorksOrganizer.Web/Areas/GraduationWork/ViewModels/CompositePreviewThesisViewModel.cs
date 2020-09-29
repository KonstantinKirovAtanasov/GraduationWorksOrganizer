namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// VM който обединява тема и UserEntry
    /// </summary>
    public class CompositePreviewThesisViewModel
    {
        /// <summary>
        /// ВМ за тема
        /// </summary>
        public PreviewThesisViewModel ThesisViewModel { get; set; }

        /// <summary>
        /// Модел за записан студент
        /// </summary>
        public UserEntryBaseViewModel UserEntry { get; set; }
    }
}
