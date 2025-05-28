using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        [Route("auth/signup")]
        // GET: AuthController
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Route("auth/signup")]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Message = "Sign up successful!";
                return View(model);
            }
            return View();
        }
        [Route("auth/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("auth/login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Message = "Login successful!";
                return View(model);
            }
            return View();
        }
       

    }
}
