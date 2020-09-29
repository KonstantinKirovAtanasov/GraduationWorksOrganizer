using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Additional.Services
{
    public class MapperService
    {
        public IEnumerable<TMapperVM> GetViewModels<TMapperVM>(IEnumerable collection) where TMapperVM : class, IAutoMapperViewModel, new()
        {
            Mapper mapper = new Mapper(new TMapperVM().GetMapperConfiguration());
            foreach (var model in collection)
            {
                yield return mapper.Map<TMapperVM>(model);
            }
        }
    }
}
