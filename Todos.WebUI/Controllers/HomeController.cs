using Microsoft.AspNetCore.Mvc;

namespace Todos.WebUI.Controllers
{
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