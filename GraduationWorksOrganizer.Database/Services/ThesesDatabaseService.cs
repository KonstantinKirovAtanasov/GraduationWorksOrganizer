﻿using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// ДБ Сървис за работа с теми
    /// </summary>
    public class ThesesDatabaseService
    {
        #region Declarations

        /// <summary>
        /// Дата контекст
        /// </summary>
        private GraduationWorksOrganizerDataContext _dbContext;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public ThesesDatabaseService(GraduationWorksOrganizerDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод който връща всички теми
        /// </summary>
        /// <returns></returns>
        public IQueryable<Theses> GetAll()
        {
            return _dbContext.Theses;
        }

        /// <summary>
        /// Метод за добавяне на теза
        /// </summary>
        /// <param name="thesis"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(Theses thesis)
        {
            await _dbContext.Theses.AddAsync(thesis);
            return await _dbContext.SaveChangesAsync().ContinueWith(t => !t.IsFaulted);
        }

        /// <summary>
        /// Метод който взима темата по ИД-то
        /// </summary>
        /// <param name="thesisId"></param>
        /// <returns></returns>
        public async Task<Theses> GeyById(int thesisId)
        {
            return await _dbContext.Theses.FindAsync(thesisId);
        }

        /// <summary>
        /// Метод който взима темата по ИД-то и взима релация
        /// </summary>
        /// <param name="thesisId"></param>
        /// <returns></returns>
        public async Task<Theses> GeyById(int thesisId, Expression<Func<Theses, IDatabaseEntity>> includeExpression)
        {
            ////                           TO DO: Repair this shit DecoratorOrBuilderPattern
            return await _dbContext.Theses.Include(t => t.Requerments).Include(includeExpression).FirstOrDefaultAsync(t => t.Id == thesisId);
        }

        #endregion
    }
}
