using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.Defence.ViewModels
{
    public class DefenceDatesViewModel : IAutoMapperViewModel
    {
        public int Id { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime EndDate { get; set; }

        public string HallNumber { get; set; }

        public int ThesesCount { get; set; }

        public int MaxThesisCount { get; set; }

        public string TeacherName { get; set; }

        public string TeacherScienceDegree { get; set; }

        public string ShortDescription { get; set; }

        public IEnumerable<InnerThesesViewModel> Theseses { get; set; }

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
            expression.CreateMap<TeacherDefencesDates, DefenceDatesViewModel>()
                      .ForMember(s => s.ThesesCount, dest => dest.MapFrom(p => p.Defences.Count))
                      .ForMember(s => s.TeacherName, dest => dest.MapFrom(dd => dd.Teacher.Name))
                      .ForMember(s => s.TeacherScienceDegree, dest => dest.MapFrom(dd => dd.Teacher.ScienceDegree));
        }

        #endregion


    }
}
