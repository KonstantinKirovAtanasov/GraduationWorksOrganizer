﻿using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels.InnerViewModels;
using System;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// VM за теза
    /// </summary>
    public class ThesesViewModel : IAutoMapperViewModel
    {

        #region  Properties

        /// <summary>
        /// Ид на тезата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заглавие
        /// </summary>
        public string Title { get; set; }

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
        public InnerSubjectViewModel Subject { get; set; }

        /// <summary>
        /// Създател
        /// </summary>
        public InnerApplicationUserViewModel Creator { get; set; }

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
            expression.CreateMap<Theses, ThesesViewModel>();
            expression.CreateMap<ApplicationIdentityBase, InnerApplicationUserViewModel>();
            expression.CreateMap<Subject, InnerSubjectViewModel>();
        }

        #endregion

    }
}
