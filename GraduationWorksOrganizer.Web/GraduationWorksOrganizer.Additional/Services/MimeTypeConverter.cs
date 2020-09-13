using GraduationWorksOrganizer.Core.Additional;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using System.Linq;

namespace GraduationWorksOrganizer.Additional.Services
{
    public class MimeTypeConverter : IMimeTypeConverter
    {
        private const string DEFAULT_MIMETYPE = "application/octet-stream";
        private readonly IQueryProvider<MimeType> _dbService;

        public MimeTypeConverter(IQueryProvider<MimeType> dbService)
        {
            _dbService = dbService;
        }

        public string GetMimeTypeByPartialPath(string partialPath)
        {
            string fileExtention = partialPath.Split('.').Last();
            return _dbService.GetQuery().FirstOrDefault(mt => mt.FileExtention.EndsWith(fileExtention)).MIMEType ?? DEFAULT_MIMETYPE;
        }
    }
}
