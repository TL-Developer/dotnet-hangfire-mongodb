using Microsoft.AspNetCore.Mvc;
using Worker.Services;

namespace Worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddAgendamento()
        {
            WorkerService.Agendamento();

            return Ok();
        }
    }
}
