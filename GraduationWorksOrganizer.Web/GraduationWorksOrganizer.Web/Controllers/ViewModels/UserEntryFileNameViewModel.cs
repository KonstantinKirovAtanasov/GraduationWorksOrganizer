using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;

namespace GraduationWorksOrganizer.Web.Controllers.ViewModels
{
    /// <summary>
    /// ВМ за показване на качени файлове
    /// </summary>
    public class UserEntryFileNameViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Ид на файла
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// име на файла
        /// </summary>
        public string FileName { get; set; }

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
            expression.CreateMap<ThesisUserEntryFileContent, UserEntryFileNameViewModel>();
        }
    }
}
