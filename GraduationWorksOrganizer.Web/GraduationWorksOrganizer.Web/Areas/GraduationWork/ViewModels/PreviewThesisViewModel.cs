using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// Клас за преглед на тема
    /// </summary>
    public class PreviewThesisViewModel : ThesesViewModel, IAutoMapperViewModel
    {
        /// <summary>
        /// Клас за изисквания
        /// </summary>
        public IEnumerable<RequermentViewModel> Requerments { get; set; }

        /// <summary>
        /// Конфигурация за ауто мапер
        /// </summary>
        public override MapperConfiguration Configuration { get; set; }
            = new MapperConfiguration(c =>
            {
                c.CreateMap<Theses, PreviewThesisViewModel>();
                c.CreateMap<ApplicationIdentityBase, InnerApplicationUserViewModel>();
                c.CreateMap<Specialty, InnerSpecialtyViewModel>();
                c.CreateMap<ThesisRequerment, RequermentViewModel>();
            });
    }
}
