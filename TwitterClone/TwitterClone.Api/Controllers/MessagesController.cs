using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
