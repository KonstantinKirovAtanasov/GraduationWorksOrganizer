﻿using AutoMapper;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.MapEntitiesServices
{
    /// <summary>
    /// Сървис за работа с учители
    /// </summary>
    public class ThesisViewModelService<TViewModel> : IViewModelService<TViewModel, Teacher> where TViewModel : IAutoMapperViewModel, new()
    {
        #region Declarations

        /// <summary>
        /// ДБ сървис
        /// </summary>
        private readonly ThesesDatabaseService _databaseService;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntriesDbService;

        /// <summary>
        /// Аутомаппер
        /// </summary>
        private readonly Mapper _automapper;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public ThesisViewModelService(ThesesDatabaseService databaseService,
                                      CombinedQueryBaseService<ThesesUserEntry> userEntriesDbService)
        {
            _databaseService = databaseService;
            _userEntriesDbService = userEntriesDbService;
            _automapper = new Mapper(new TViewModel().GetMapperConfiguration());
        }

        #endregion

        /// <summary>
        /// Метод който връща всички модели от базата като ViewModel-и
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TViewModel> GetViewModels()
        {
            IQueryable<Theses> thesises = _databaseService.GetAllIncluding(t => t.Subject, t => t.Creator);
            foreach (Theses thesis in thesises)
                yield return _automapper.Map<TViewModel>(thesis);
        }

        /// <summary>
        /// Метод който връща всички модели от базата като ViewModel-и според предиката
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TViewModel> GetViewModels(Expression<Func<Theses, bool>> predicate)
        {
            IQueryable<Theses> theseses = _databaseService.GetAllIncluding(t => t.Subject
                                                                         , t => t.Requerments
                                                                         , t => t.Creator);
            if (predicate != null)
                theseses = theseses.Where(predicate);

            foreach (Theses thesis in theseses)
                yield return _automapper.Map<TViewModel>(thesis);
        }

        /// <summary>
        /// Добавяне
        /// </summary>
        /// <param name="theses"></param>
        /// <returns></returns>
        public async Task AddAsync(IAutoMapperViewModel thesesVM)
        {
            Mapper mapper = new Mapper(thesesVM.GetMapperConfiguration());
            Theses theses = mapper.Map<Theses>(thesesVM);

            theses.CreationDate = DateTime.Now;
            await _databaseService.Add(theses);
        }

        /// <summary>
        /// Метод който връща ВМ на тема
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TViewModel> GetViewModel(int id)
        {
            Theses thesis = await _databaseService.GetAllIncluding(t => t.Subject, t => t.Requerments, t => t.Creator).FirstOrDefaultAsync(t => t.Id == id);
            return _automapper.Map<TViewModel>(thesis);
        }

        /// <summary>
        /// Метод който връща записа на студент за конкретна теза
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ThesesUserEntry> GetUserEntry(string userId, int thesisId)
        {
            ThesesUserEntry userEntry = await _userEntriesDbService.GetQuery().FirstOrDefaultAsync(te => te.StudentId == userId && te.ThesesId == thesisId);
            return userEntry;
        }
    }
}