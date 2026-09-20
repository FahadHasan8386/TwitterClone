using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class FollowsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
