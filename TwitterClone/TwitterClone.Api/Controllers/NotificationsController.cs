using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
