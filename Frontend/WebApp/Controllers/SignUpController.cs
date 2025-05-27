using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUpController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would typically save the user to the database
                // and possibly redirect to a confirmation page or login page.
                // For now, we'll just return a success message.
                ViewBag.Message = "Sign up successful!";
                return View("Success");
            }
            return View();
        }

        

    }
}
