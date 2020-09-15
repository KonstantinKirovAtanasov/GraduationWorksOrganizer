using GraduationWorksOrganizer.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TeachersDatabaseService
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private readonly GraduationWorksOrganizerDataContext _dataContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public TeachersDatabaseService(GraduationWorksOrganizerDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Teacher> GetTeachers()
        {
            return _dataContext.Teachers;
        }

        /// <summary>
        /// Метод който взима учител
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacher(string teacherId)
        {
            if (string.IsNullOrEmpty(teacherId))
                return null;

            return await _dataContext.Teachers.FindAsync(teacherId);
        }

        /// <summary>
        /// Метод който взима учител
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Teacher>> GetManyTeachers(IEnumerable<Teacher> teachers)
        {
            IEnumerable<Task<Teacher>> getTeachersTasks = teachers.Select(t => GetTeacher(t.Id));
            await Task.WhenAll(getTeachersTasks.ToArray());
            return getTeachersTasks.Select(t => t.Result);
        }

    }
}
