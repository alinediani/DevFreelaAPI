using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
