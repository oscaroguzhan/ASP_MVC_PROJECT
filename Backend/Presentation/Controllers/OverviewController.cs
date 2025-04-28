using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OverviewController : Controller
    {
        [Route("/admin/overview")]
        // GET: OverviewController
        public ActionResult Index()
        {
            return View();
        }

    }
}
