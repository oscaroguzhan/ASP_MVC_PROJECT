using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ExternalAuthController : Controller
    {
        [HttpPost]
        // GET: ExternalAuthController
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExternalCallBack()
        {
            return View();
        }

    }
}
