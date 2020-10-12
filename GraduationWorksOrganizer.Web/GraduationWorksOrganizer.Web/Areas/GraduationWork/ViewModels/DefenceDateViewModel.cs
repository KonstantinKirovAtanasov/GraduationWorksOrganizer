using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    public class DefenceDateViewModel : IAutoMapperViewModel
    {
        public int Id { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndDate { get; set; }

        public string HallNumber { get; set; }

        public int ThesesCount { get; set; }

        public int MaxThesisCount { get; set; }

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
            expression.CreateMap<TeacherDefencesDates, DefenceDateViewModel>()
                      .ForMember(s => s.ThesesCount, dest => dest.MapFrom(p => p.Defences.Count));
        }

        #endregion

    }
}
