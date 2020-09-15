using AutoMapper;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.Services
{
    /// <summary>
    /// Сървис за работа с тези
    /// </summary>
    public class ThesisService
    {
        /// <summary>
        /// ДБ Сървис
        /// </summary>
        private readonly ThesesDatabaseService _dbService;
        private readonly StudentDatabaseService _studentsService;
        private readonly TeachersDatabaseService _teacherDbService;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _thEntryDbService;
        private readonly IAsyncRepository<ThesisApprovementRequest> _thApproveRequestDbService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbService"></param>
        public ThesisService(ThesesDatabaseService dbService,
                             StudentDatabaseService studentsService,
                             TeachersDatabaseService teacherDbService,
                             IAsyncRepository<ThesisApprovementRequest> thApproveRequestDbService,
                             CombinedQueryBaseService<ThesesUserEntry> thEntryDbService)
        {
            _dbService = dbService;
            _studentsService = studentsService;
            _teacherDbService = teacherDbService;
            _thApproveRequestDbService = thApproveRequestDbService;
            _thEntryDbService = thEntryDbService;
        }

        /// <summary>
        /// Метод който записва за тема
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="thesesId"></param>
        /// <returns></returns>
        public async Task ApplyForTheThesis(string userId, int thesesId)
        {
            ThesesUserEntry thesesUserEntry = new ThesesUserEntry() { StudentId = userId, ThesesId = thesesId };
            thesesUserEntry.State = Common.Enums.ThesisUserEntryState.Initialized;
            Theses theses = await _dbService.GetById(thesesId);
            theses.UserEntries.Add(thesesUserEntry);
            await _dbService.Update(theses);
        }

        /// <summary>
        /// Метод който валидира дали студента може да се запише за темата
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="thesesId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ValidationResult>> ValidateApply(string userId, int thesesId)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            IQueryable<ThesesUserEntry> thesesEntries = _dbService.GetThesisUserEntries(thesesId);
            if (await thesesEntries.AnyAsync(tue => tue.StudentId == userId))
            {
                result.Add(new ValidationResult("Вече сте записани за тази тема, един студент може да се запише само един път за опреелена тема"));
            }

            Specialty userSpecialty = await _studentsService.GetStudentSpecialty(userId);
            if (_dbService.GetAllIncluding(t => t.Subject).FirstOrDefault(t => t.Id == thesesId && t.Subject.SpecialtyId == userSpecialty.Id) == null)
            {
                result.Add(new ValidationResult("Не може да се запишете за тази тема, темата за която се записвате трябва да е за вашата специалност"));
            }

            return result;
        }

        /// <summary>
        /// Метод които изпраща 
        /// </summary>
        /// <returns></returns>
        public async Task SendForApprovement(IAutoMapperViewModel addViewModel)
        {
            Mapper mapper = new Mapper(addViewModel.GetMapperConfiguration());
            ThesisApprovementRequest request = mapper.Map<ThesisApprovementRequest>(addViewModel);
            ThesesUserEntry userEntry = await _thEntryDbService.GetById(request.ThesesUserEntryId);
            userEntry.State = Common.Enums.ThesisUserEntryState.SendForApprovement;

            await _thEntryDbService.Update(userEntry);
            await _thApproveRequestDbService.Add(request);
        }
    }
}
