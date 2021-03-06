﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Common.Attributes
{
    /// <summary>
    /// Атрибут за име на тип който е енъм но се пази в базата като самостоятелна таблица
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class EntityEnumNameAttribute : Attribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public EntityEnumNameAttribute()
        {

        }
    }
}
