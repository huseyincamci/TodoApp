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

        [HttpGet("api/item/{id}")]
        public IActionResult Get(int id)
        {
            var item =  _itemService.GetItemById(id);
            return Ok(item);
        }

        [HttpPost("api/item")]
        public async Task<IActionResult> Post([FromBody] ItemDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Deadline = itemDto.Deadline,
                Status = itemDto.Status
            };
            await _itemService.CreateItem(itemDto.TodoId, item);
            return Ok(new { Created = true });
        }

        [HttpPut("api/item")]
        public async Task<IActionResult> Put([FromBody] ItemDto itemDto)
        {
            var item = new Item
            {
                Id = itemDto.TodoId,
                Name = itemDto.Name,
                Description = itemDto.Description,
                Deadline = itemDto.Deadline,
                Status = itemDto.Status
            };
            await _itemService.EditItem(item);
            return Ok(new { Edit = true });
        }

        [HttpDelete("api/item/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.DeleteItem(id);
            return NoContent();
        }
    }
}