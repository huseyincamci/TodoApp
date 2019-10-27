using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todos.Data.Models;

namespace Todos.Data
{
    public interface IItemService
    {
        Item GetItemById(int id);
        IEnumerable<Item> GetAllItemsByTodoListId();

        Task CreateItem(int todoListId, Item item);
        Task DeleteItem(int id);
        Task MarkItemAsComplete(int id);
    }
}
