using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
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

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbService"></param>
        public ThesisService(ThesesDatabaseService dbService)
        {
            _dbService = dbService;
        }

        /// <summary>
        /// Метод за одобрение на тема
        /// </summary>
        /// <param name="theses"></param>
        /// <returns></returns>
        public async Task<bool> ApproveThesis(Theses theses)
        {
            theses.Status = Common.Enums.ThesesStatusType.Accept;
            await _dbService.Update(theses);
            return true;
        }

        /// <summary>
        /// Метод за отказване на тема
        /// </summary>
        /// <param name="theses"></param>
        /// <returns></returns>
        public async Task<bool> RejectThesis(Theses theses)
        {
            theses.Status = Common.Enums.ThesesStatusType.Reject;
            await _dbService.Update(theses);
            return true;
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
            Theses theses = await _dbService.GetById(thesesId);
            theses.UserEntries.Add(thesesUserEntry);
            await _dbService.Update(theses);
        }
    }
}
