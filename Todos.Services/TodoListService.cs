using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Data.Models;

namespace Todos.Services
{
    public class TodoListService : ITodoListService
    {
        public TodoListService(ApplicationDbContext context)
        {
            Context = context;
        }

        protected ApplicationDbContext Context { get; }

        public async Task CreateTodoList(TodoList todoList)
        {
            Context.TodoList.Add(todoList);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteTodoList(int id)
        {
            var todoList = GetTodoListById(id);
            Context.TodoList.Remove(todoList);
            Context.Items.RemoveRange(Context.Items.Where(i => i.Todos.Id == id));
            await Context.SaveChangesAsync();
        }

        public IEnumerable<TodoList> GetAllTodoList()
        {
            return Context.TodoList;
        }

        public IEnumerable<TodoList> GetAllTodoListByUserId(string userId)
        {
            return Context.TodoList.Where(t => t.User.Id == userId);
        }

        public TodoList GetTodoListById(int id)
        {
            return Context.TodoList.FirstOrDefault(t => t.Id == id);
        }
    }
}
