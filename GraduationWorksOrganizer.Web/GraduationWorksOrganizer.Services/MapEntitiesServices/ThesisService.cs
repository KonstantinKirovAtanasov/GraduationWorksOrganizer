using AutoMapper;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.MapEntitiesServices
{
    /// <summary>
    /// Сървис за работа с учители
    /// </summary>
    public class ThesisService<TViewModel> : IViewModelService<TViewModel, Teacher> where TViewModel : IAutoMapperViewModel, new()
    {
        #region Declarations

        /// <summary>
        /// ДБ сървис
        /// </summary>
        private readonly ThesesDatabaseService _databaseService;

        /// <summary>
        /// Аутомаппер
        /// </summary>
        private readonly Mapper _automapper;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public ThesisService(ThesesDatabaseService databaseService)
        {
            _databaseService = databaseService;
            _automapper = new Mapper(new TViewModel().Configuration);
        }

        #endregion

        /// <summary>
        /// Метод който връща всички модели от базата като ViewModel-и
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TViewModel> GetViewModels()
        {
            IQueryable<Theses> thesises = _databaseService.GetAll().Include(t => t.TargetSpecialty).Include(t => t.Approval).Include(t => t.Creator);
            foreach (Theses thesis in thesises)
                yield return _automapper.Map<TViewModel>(thesis);
        }

        /// <summary>
        /// Добавяне
        /// </summary>
        /// <param name="theses"></param>
        /// <returns></returns>
        public async Task Add(Theses theses)
        {
            await Task.CompletedTask;
        }

    }
}