﻿using GraduationWorksOrganizer.Core.Database.Models;
using System;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Оценка на защитата
    /// </summary>
    public class ThesisMark : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public double Mark { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

    }
}