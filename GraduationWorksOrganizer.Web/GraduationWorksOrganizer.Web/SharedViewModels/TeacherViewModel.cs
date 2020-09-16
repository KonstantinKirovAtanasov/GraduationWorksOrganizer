using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;

namespace GraduationWorksOrganizer.Web.SharedViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TeacherViewModel : IAutoMapperViewModel
    {
        #region Properties

        /// <summary>
        /// Ид
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Име
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Научна степен
        /// </summary>
        public string ScienceDegree { get; set; }

        /// <summary>
        /// Катедра
        /// </summary>
        public InnerDepartmentViewModel Department { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>
        public InnerImageViewModel Image { get; set; }

        #endregion

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
            expression.CreateMap<Teacher, TeacherViewModel>();
            expression.CreateMap<Department, InnerDepartmentViewModel>();
            expression.CreateMap<FileContent, InnerImageViewModel>();
        }

        #endregion

        /// <summary>
        /// Вътрешен клас за катедра
        /// </summary>
        public class InnerDepartmentViewModel
        {
            /// <summary>
            /// Ид на катедрата
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Име
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// Вм за картинка
        /// </summary>
        public class InnerImageViewModel
        {
            public byte[] Content { get; set; }
        }
    }
}
