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
        public int TargetSpecialtyId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Колекция с изисквания
        /// </summary>
        public List<RequermentViewModel> Requerments { get; set; }

        /// <summary>
        /// Конфигурация за АутоМаппер-а
        /// </summary>
        public MapperConfiguration Configuration { get; set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AddThesisViewModel, Theses>();
            cfg.CreateMap<RequermentViewModel, ThesisRequerment>();
        });

        /// <summary>
        /// Ид на Създателя на темата
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// Id на създателя на темата
        /// </summary>
        public ThesesStatusType Status { get; set; }
    }
}