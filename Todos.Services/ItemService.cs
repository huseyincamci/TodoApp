using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Data.Models;

namespace Todos.Services
{
    public class ItemService : IItemService
    {
        public ItemService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected ApplicationDbContext Context { get; }

        public async Task CreateItem(int todoListId, Item item)
        {
            var todoList = Context.TodoList.FirstOrDefault(t => t.Id == todoListId);
            item.Todos = todoList;
            Context.Items.Add(item);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var todoItem = Context.Items.FirstOrDefault(i => i.Id == id);
            Context.Items.Remove(todoItem);
            await Context.SaveChangesAsync();
        }

        public async Task EditItem(Item item)
        {
            Context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public IEnumerable<Item> GetAllItemsByTodoListId(int todoListId)
        {
            return Context.Items.Where(i => i.Todos.Id == todoListId).ToList();
        }

        public Item GetItemById(int id)
        {
            return Context.Items.FirstOrDefault(i => i.Id == id);
        }

        public async Task MarkItemAsComplete(int id)
        {
            var item = Context.Items.FirstOrDefault(i => i.Id == id);
            item.Status = true;
            await Context.SaveChangesAsync();
        }
    }
}
