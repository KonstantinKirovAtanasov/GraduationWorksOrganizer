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
        /// Конфигурация за ауто мапера
        /// </summary>
        MapperConfiguration Configuration { get; set; }
    }
}
