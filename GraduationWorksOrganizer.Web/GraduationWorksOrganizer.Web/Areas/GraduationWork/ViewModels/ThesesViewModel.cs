using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using System;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// VM за теза
    /// </summary>
    public class ThesesViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Ид на тезата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заглавие
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///Дата на създаване
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public ThesesStatusType Status { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        public InnerSpecialtyViewModel TargetSpecialty { get; set; }

        /// <summary>
        /// Създател
        /// </summary>
        public InnerApplicationUserViewModel Creator { get; set; }

        /// <summary>
        /// Одобрил
        /// </summary>
        public InnerApplicationUserViewModel Approval { get; set; }


        /// <summary>
        /// Конфигурация за ауто мапер
        /// </summary>
        public MapperConfiguration Configuration { get; set; }
            = new MapperConfiguration(c =>
            {
                c.CreateMap<Theses, ThesesViewModel>();
                c.CreateMap<ApplicationIdentityBase, InnerApplicationUserViewModel>();
                c.CreateMap<Specialty, InnerSpecialtyViewModel>();
            });

        /// <summary>
        /// ВМ за специалност
        /// </summary>
        public class InnerSpecialtyViewModel
        {
            /// <summary>
            /// Ид
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Наименование
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// ВМ за специалност
        /// </summary>
        public class InnerApplicationUserViewModel
        {
            /// <summary>
            /// Ид
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// Наименование
            /// </summary>
            public string Name { get; set; }
        }
    }
}
