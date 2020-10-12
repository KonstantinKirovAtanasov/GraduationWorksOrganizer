using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Commissions.ViewModels
{
    public class PreviewTeacherViewModel : IAutoMapperViewModel
    {
        public string TeacherId { get; set; }

        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public string ScienceDegree { get; set; }

        public string Cabinet { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] Image { get; set; }

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
            expression.CreateMap<Teacher, PreviewTeacherViewModel>()
                      .ForMember(s => s.DepartmentName, dest => dest.MapFrom(t => t.Department.Name))
                      .ForMember(s => s.Image, dest => dest.MapFrom(t => t.Image.Content))
                      .ForMember(s => s.TeacherId, dest => dest.MapFrom(t => t.Id));
        }

        #endregion
    }
}
