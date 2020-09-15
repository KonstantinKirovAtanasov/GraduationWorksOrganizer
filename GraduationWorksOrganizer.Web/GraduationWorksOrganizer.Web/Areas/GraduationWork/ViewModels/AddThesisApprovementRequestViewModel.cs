using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AddThesisApprovementRequestViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Ид на тезата
        /// </summary>
        [Required]
        public int ThesesUserEntryId { get; set; }

        /// <summary>
        /// Id на наблюдаващ темата
        /// </summary>
        [Required]
        public string ThemeObserverId { get; set; }

        /// <summary>
        /// Описание на Request-а
        /// </summary>
        public string RequestDescription { get; set; }

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
            expression.CreateMap<AddThesisApprovementRequestViewModel, ThesisApprovementRequest>();
        }

        #endregion
    }
}
