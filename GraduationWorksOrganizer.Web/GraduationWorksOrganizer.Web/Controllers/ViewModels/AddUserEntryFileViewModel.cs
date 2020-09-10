using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationWorksOrganizer.Web.Controllers.ViewModels
{
    /// <summary>
    /// VM за добавяне на файл
    /// </summary>
    public class AddUserEntryFileViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Ид на студентската тема
        /// </summary>
        public int UserEntryId { get; set; }

        /// <summary>
        /// Съдържание на файла
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Име на файла
        /// </summary>
        public string FileName { get; set; }

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
            expression.CreateMap<AddUserEntryFileViewModel, ThesisUserEntryFileContent>();
        }

        #endregion
    }
}
