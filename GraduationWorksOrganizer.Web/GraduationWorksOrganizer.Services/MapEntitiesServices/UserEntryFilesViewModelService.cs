using AutoMapper;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.MapEntitiesServices
{
    /// <summary>
    /// 
    /// </summary>
    public class UserEntryFilesViewModelService<TViewModel> : IViewModelService<TViewModel, ThesisUserEntryFileContent> where TViewModel : IAutoMapperViewModel, new()
    {
        /// <summary>
        /// Сървис за работа с базата
        /// </summary>
        private UserEntryFilesDatabaseService _databaseService;

        /// <summary>
        /// Аутомаппер
        /// </summary>
        private readonly Mapper _automapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserEntryFilesViewModelService(UserEntryFilesDatabaseService databaseService)
        {
            _databaseService = databaseService;
            _automapper = new Mapper(new TViewModel().GetMapperConfiguration());
        }

        /// <summary>
        ///  Метод който връща всички ThesisUserEntryFileContent
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TViewModel> GetViewModels()
        {
            IQueryable<ThesisUserEntryFileContent> fileContentQuery = _databaseService.GetQuery();
            foreach (ThesisUserEntryFileContent file in fileContentQuery)
                yield return _automapper.Map<TViewModel>(file);
        }

        /// <summary>
        /// Метод който връща списък от ВМ според тезата
        /// </summary>
        /// <param name="thesisId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TViewModel>> GetThesisUserEntries(int userEntryId)
        {
            List<ThesisUserEntryFileContent> resultSet = await _databaseService.GetQuery().Where(t => t.UserEntryId == userEntryId).ToListAsync();
            return resultSet.Select(r => _automapper.Map<TViewModel>(r));
        }

        /// <summary>
        /// Метод който записва UserEntryFile
        /// </summary>
        /// <returns></returns>
        public async Task<TViewModel> AddUserEntryFile(IAutoMapperViewModel addViewModel)
        {
            Mapper mapper = new Mapper(addViewModel.GetMapperConfiguration());
            ThesisUserEntryFileContent fileContent = mapper.Map<ThesisUserEntryFileContent>(addViewModel);
            fileContent = await _databaseService.AddAsync(fileContent);
            return _automapper.Map<TViewModel>(fileContent);
        }
    }
}
