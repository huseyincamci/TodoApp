using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todos.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadTodoModal()
        {
            return PartialView("_CreateTodoList");
        }
    }
}