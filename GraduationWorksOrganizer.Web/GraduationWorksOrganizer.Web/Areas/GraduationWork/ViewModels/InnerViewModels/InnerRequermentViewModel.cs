using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// Вътрешен ВМ за изискване
    /// </summary>
    public class InnerRequermentViewModel
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Максимален брой точки
        /// </summary>
        public decimal MaxPointsCount { get; set; }
    }
}
