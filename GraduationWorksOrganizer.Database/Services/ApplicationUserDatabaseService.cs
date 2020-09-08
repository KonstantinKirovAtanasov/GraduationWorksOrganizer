using GraduationWorksOrganizer.Database.Models.Base;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// Сървис за работа с applicationUser-a
    /// </summary>
    public class ApplicationUserDatabaseService
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private readonly GraduationWorksOrganizerDataContext _dataContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public ApplicationUserDatabaseService(GraduationWorksOrganizerDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Метод за смяна на снимката на потребителя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="image"></param>
        public async Task ChangeUserPhoto(ApplicationIdentityBase user, byte[] image)
        {
            ApplicationIdentityBase contextUser = await _dataContext.Users.FindAsync(user.Id) as ApplicationIdentityBase;
            contextUser.Image = new FileContent() { Content = image };
            await _dataContext.SaveChangesAsync();
        }
    }
}
