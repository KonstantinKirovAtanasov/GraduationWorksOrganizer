using GraduationWorksOrganizer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public interface IViewModelService<TViewModel, TEntity> where TViewModel : IAutoMapperViewModel
    {
        /// <summary>
        /// Метод който връща ВМ
        /// </summary>
        /// <returns></returns>
        IEnumerable<TViewModel> GetViewModels();
    }
}
