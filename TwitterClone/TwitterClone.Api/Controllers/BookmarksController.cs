using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class BookMarksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
