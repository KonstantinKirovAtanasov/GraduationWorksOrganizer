using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Services.MapEntitiesServices.ViewModels
{
    /// <summary>
    /// Клас за добавяне на тема
    /// </summary>
    public class AddThesisViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Заглавие
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Колекция с изисквания
        /// </summary>
        public List<RequermentViewModel> Requerments { get; set; }

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
            expression.CreateMap<AddThesisViewModel, Theses>();
            expression.CreateMap<RequermentViewModel, ThesisRequerment>();
        }

        #endregion

        /// <summary>
        /// Ид на Създателя на темата
        /// </summary>
        public string CreatorId { get; set; }
    }
}