using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class LikesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
