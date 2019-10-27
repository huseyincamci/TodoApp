using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todos.Data.Models;

namespace Todos.Data
{
    public interface ITodoListService
    {
        TodoList GetTodoListById(int id);
        IEnumerable<TodoList> GetAllTodoList();

        Task CreateTodoList(TodoList todoList);
        Task DeleteTodoList(int id);
    }
}
