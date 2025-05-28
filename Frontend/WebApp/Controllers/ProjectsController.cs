
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Projects = SetProjects(),
                AddProjectFormData = new AddProjectViewModel
                {
                    Clients = SetClients(),
                    Members = SetMembers()
                },
                EditProjectFormData = new EditProjectViewModel
                {
                    Clients = SetClients(),
                    Members = SetMembers(),
                    Statuses = SetStatuses()
                }
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

        private IEnumerable<SelectListItem> SetClients()
        {
            var clients = new List<SelectListItem>
            {
                new() { Value = "1", Text = "EPN Sverige AB" },
                new() { Value = "2", Text = "Microsoft " },
                new() { Value = "3", Text = "Google" }
            };
            return clients;
        }
        private IEnumerable<SelectListItem> SetMembers()
        {
            var members = new List<SelectListItem>
            {
                new() { Value = "1", Text = "Oscar" },
                new() { Value = "2", Text = "John " },
                new() { Value = "3", Text = "Jane" }
            };
            return members;
        }
        private IEnumerable<SelectListItem> SetStatuses()
        {
            var statuses = new List<SelectListItem>
            {
                new() { Value = "1", Text = "Started", Selected = true },
                new() { Value = "2", Text = "Completed " },
                
            };
            return statuses;
        }

        
    }
}
// This code defines a ProjectsController in an ASP.NET Core MVC application.