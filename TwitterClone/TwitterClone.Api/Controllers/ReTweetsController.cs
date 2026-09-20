using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    public class RetweetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
