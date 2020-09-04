using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;

namespace GraduationWorksOrganizer.Web.SharedViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TeacherViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Ид
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Снимка
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Име
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Катедра
        /// </summary>
        public InnerDepartmentViewModel Department { get; set; }

        /// <summary>
        /// Конфигурация
        /// </summary>
        public MapperConfiguration Configuration { get; set; }
            = new MapperConfiguration(c =>
            {
                c.CreateMap<Teacher, TeacherViewModel>();
                c.CreateMap<Department, InnerDepartmentViewModel>();
            });

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
    }
}
