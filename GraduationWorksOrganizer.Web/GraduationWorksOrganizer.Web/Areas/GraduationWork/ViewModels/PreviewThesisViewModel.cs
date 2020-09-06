﻿using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using System.Collections.Generic;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// Клас за преглед на тема
    /// </summary>
    public class PreviewThesisViewModel : ThesesViewModel, IAutoMapperViewModel
    {
        /// <summary>
        /// Одобрил
        /// </summary>
        public InnerApplicationUserViewModel Approval { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Клас за изисквания
        /// </summary>
        public IEnumerable<RequermentViewModel> Requerments { get; set; }

        /// <summary>
        /// Метод за конфигурация
        /// </summary>
        /// <param name="expression"></param>
        protected override void ConfigureMap(IMapperConfigurationExpression expression)
        {
            base.ConfigureMap(expression);
            expression.CreateMap<Theses, PreviewThesisViewModel>();
            expression.CreateMap<ThesisRequerment, RequermentViewModel>();
        }
    }
}
