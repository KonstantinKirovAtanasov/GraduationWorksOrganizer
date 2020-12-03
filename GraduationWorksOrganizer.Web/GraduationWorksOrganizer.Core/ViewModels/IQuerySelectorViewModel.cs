using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.ViewModels
{
    public interface IQuerySelectorViewModel<TEntityType, TViewModelType>
    {
        Func<TEntityType, TViewModelType> GetQuerySelector();
    }
}
