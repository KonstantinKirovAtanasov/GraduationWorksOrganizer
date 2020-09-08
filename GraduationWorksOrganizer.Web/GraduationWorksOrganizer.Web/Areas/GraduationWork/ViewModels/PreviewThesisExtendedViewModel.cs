using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// Разширен ВМ който показва и User-Entry-то
    /// </summary>
    public class PreviewThesisExtendedViewModel : PreviewThesisViewModel, IAutoMapperViewModel
    {
        /// <summary>
        /// Записвания на трудентите на текущата тема
        /// </summary>
        public IEnumerable<UserEntryViewModel> UserEntries { get; set; }

        /// <summary>
        /// овъррайд за ConfigureMap
        /// </summary>
        /// <param name="expression"></param>
        protected override void ConfigureMap(IMapperConfigurationExpression expression)
        {
            base.ConfigureMap(expression);
            expression.CreateMap<Theses, PreviewThesisExtendedViewModel>();
            expression.CreateMap<ThesesUserEntry, UserEntryViewModel>();
        }
    }
}
