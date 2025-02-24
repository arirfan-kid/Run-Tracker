using Microsoft.AspNetCore.Mvc;

namespace SampleCrudApp.Controllers
{
    public class PlannedRunsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
