using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.Services
{
    public class ThesisApprovementService
    {
        #region Declarations

        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryService;

        #endregion

        #region Constructor

        public ThesisApprovementService(CombinedQueryBaseService<ThesesUserEntry> userEntryService)
        {
            _userEntryService = userEntryService;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<ThesesUserEntry>> GetTeacherTheses(string teacherId)
        {
            return await _userEntryService.GetAllIncluding(e => e.Theses, e => e.ThesesRequests, e => e.Student, e => e.Theses.Subject)
                                          .Where(te => te.ThesesRequests.Any(r => r.ThemeObserverId == teacherId))
                                          .ToListAsync();
        }

        #endregion

    }
}
