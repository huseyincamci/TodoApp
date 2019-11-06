using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todos.Data;
using Todos.Data.Models;
using Todos.WebUI.Models;

namespace Todos.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("api/item")]
        public async Task<IActionResult> Post([FromBody] ItemDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Deadline = itemDto.Deadline,
                Status = false
            };
            await _itemService.CreateItem(itemDto.TodoId, item);
            return Ok(new { Created = true });
        }
    }
}