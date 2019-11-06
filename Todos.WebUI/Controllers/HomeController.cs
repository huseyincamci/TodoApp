using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Data.Models;
using Todos.WebUI.ViewModels;

namespace Todos.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITodoListService _todoListService;
        private readonly IItemService _itemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ITodoListService todoListService,
            IItemService itemService,
            UserManager<ApplicationUser> userManager)
        {
            _todoListService = todoListService;
            _userManager = userManager;
            _itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var todoList = _todoListService.GetAllTodoListByUserId(currentUser.Id).ToList();

            var todoListViewModel = todoList.Select(t => new TodoListViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Items = _itemService.GetAllItemsByTodoListId(t.Id).Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Status = i.Status
                })
            });

            var homeIndexViewModel = new HomeIndexViewModel { TodoList = todoListViewModel };

            return View(homeIndexViewModel);
        }

        public PartialViewResult LoadTodoModal()
        {
            return PartialView("_CreateTodoList");
        }

        public PartialViewResult LoadItemModal()
        {
            return PartialView("_CreateItem");
        }
    }
}