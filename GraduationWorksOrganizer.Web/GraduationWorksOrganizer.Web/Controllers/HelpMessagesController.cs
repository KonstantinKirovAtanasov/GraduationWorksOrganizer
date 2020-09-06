using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Controllers
{
    /// <summary>
    /// Апи за помощни съобщения
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HelpMessagesController : ControllerBase
    {
        /// <summary> Репоситори </summary>
        private readonly IAsyncRepository<HelpMessage> _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public HelpMessagesController(IAsyncRepository<HelpMessage> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод който връща помощно съобщение
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> GetHelpMessage(string key)
        {
            IEnumerable<HelpMessage> messages = await _repository.GetAll(hm => hm.Key.Equals(key));
            return Ok(messages.FirstOrDefault());
        }
    }
}
