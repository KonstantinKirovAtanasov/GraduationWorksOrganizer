using GraduationWorksOrganizer.Common.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraduationWorksOrganizer.Web.Helpers
{
    /// <summary>
    /// Екстеншън методи към IHTMLHelper
    /// </summary>
    public static class IHtmlHelperExtensions
    {
        /// <summary>
        /// Метод за извличане на SelectList от IEnumerable
        /// </summary>
        /// <typeparam name="TEnumEntity"></typeparam>
        /// <param name="html"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetEntityEnumSelectList<TEnumEntity>(this IHtmlHelper html, IEnumerable<TEnumEntity> values) where TEnumEntity : class
        {
            return values.Select(eachValue => new SelectListItem
            {
                Text = eachValue.GetType().GetProperties().FirstOrDefault(p => p.GetCustomAttribute<EntityEnumNameAttribute>() != null).GetValue(eachValue).ToString(),
                Value = eachValue.GetType().GetProperties().FirstOrDefault(p => p.GetCustomAttribute<EntityEnumValueAttribute>() != null).GetValue(eachValue).ToString()
            });
        }
    }
}
