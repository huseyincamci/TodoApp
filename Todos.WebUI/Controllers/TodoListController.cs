using Microsoft.AspNetCore.Authorization;
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

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpPost("api/todos")]
        public async Task<IActionResult> Post([FromBody]TodoListRequest todoListDto)
        {
            var todoList = new TodoList
            {
                Name = todoListDto.Name,
                Created = DateTime.UtcNow,
                User = null
            };
            await _todoListService.CreateTodoList(todoList);
            return Ok(todoListDto.Name);
        }
    }
}