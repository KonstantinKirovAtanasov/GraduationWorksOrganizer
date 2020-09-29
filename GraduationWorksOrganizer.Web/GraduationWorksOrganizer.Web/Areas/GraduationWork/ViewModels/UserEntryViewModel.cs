using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels.InnerViewModels;
using System;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    public class UserEntryViewModel : UserEntryBaseViewModel, IAutoMapperViewModel
    {
        public InnerStudentViewModel Student { get; set; }

        public DateTime CreationDate { get; set; }

        #region IAutoMapperViewModel

        /// <summary>
        /// Метод който връща конфигурацията на АутоМапер-а
        /// </summary>
        /// <returns></returns>
        public MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(ConfigureMap);
        }

        /// <summary>
        /// Метод за конфигурация
        /// </summary>
        /// <param name="expression"></param>
        protected virtual void ConfigureMap(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ThesesUserEntry, UserEntryViewModel>();
            expression.CreateMap<Student, InnerStudentViewModel>();
        }

        #endregion


    }
}