
using Microsoft.AspNetCore.Mvc;

using WebApp.Models;


namespace WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        [Route("admin/projects")]
        public IActionResult Index()
        {
            var viewModel = new ProjectsViewModel()
            {
                Projects = SetProjects()
            };
            return View(viewModel);
        }

        private IEnumerable<ProjectViewModel> SetProjects()
        {
            var projects = new List<ProjectViewModel>
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProjectImage = "/images/Image.svg",
                    ProjectName = "Project Alpha",
                    ClientName = "Client A",
                    Description = "<p>Description of <strong>Project Alpha</strong></p>",
                    TimeLeft = "2 weeks",
                    Members = ["/images/user_avatar.svg", "/images/user_avatar2.svg"]
                }
            };

            return projects;


        }
    }
}
// This code defines a ProjectsController in an ASP.NET Core MVC application.