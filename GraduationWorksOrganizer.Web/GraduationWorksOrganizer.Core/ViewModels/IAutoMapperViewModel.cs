using AutoMapper;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Core.ViewModels
{
    /// <summary>
    /// ВМ с конфигурация за АутоМаппер-а
    /// </summary>
    public interface IAutoMapperViewModel
    {
        /// <summary>
        /// Метод който връща конфигурацията на АутоМапер-а
        /// </summary>
        /// <returns></returns>
        MapperConfiguration GetMapperConfiguration();
    }
}
