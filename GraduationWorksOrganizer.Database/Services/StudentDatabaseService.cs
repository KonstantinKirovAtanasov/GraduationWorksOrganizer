using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// Метод за работа със студенти
    /// </summary>
    public class StudentDatabaseService
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private readonly GraduationWorksOrganizerDataContext _dataContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public StudentDatabaseService(GraduationWorksOrganizerDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// метод който връща специалността на студента
        /// </summary>
        /// <returns></returns>
        public async Task<Specialty> GetStudentSpecialty(string userId)
        {
            Student student = await _dataContext.Students.FindAsync(userId);
            return await _dataContext.Specialties.FindAsync(student.SpecialtyId);
        }
    }
}
