using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Data.Models;
using Todos.WebUI.Models;

namespace Todos.WebUI.Controllers
{
    [Authorize]
    public class TodoListController : Controller
    {
        private readonly ITodoListService _todoListService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoListController(ITodoListService todoListService,
            UserManager<ApplicationUser> userManager)
        {
            _todoListService = todoListService;
            _userManager = userManager;
        }

        [HttpPost("api/todos")]
        public async Task<IActionResult> Post([FromBody]TodoListRequest todoListDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var todoList = new TodoList
            {
                Name = todoListDto.Name,
                Created = DateTime.UtcNow,
                User = user
            };
            await _todoListService.CreateTodoList(todoList);
            return Ok(todoListDto.Name);
        }

        [HttpDelete("api/todos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoList = _todoListService.GetTodoListById(id);
            if (todoList == null)
                return NotFound();

            await _todoListService.DeleteTodoList(id);
            return NoContent();
        }
    }
}