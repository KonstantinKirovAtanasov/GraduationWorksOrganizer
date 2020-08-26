using GraduationWorksOrganizer.Core.Database;
using Microsoft.AspNetCore.Mvc;

namespace GraduationWorksOrganizer.Web.Controllers
{
    /// <summary>
    /// Апи за помощни съобщения
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HelpMessagesController : ControllerBase
    {
        /// <summary> Репоситори </summary>
        private readonly IAsyncRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public HelpMessagesController(IAsyncRepository repository)
        {
            _repository = repository;
        }
    }
}
