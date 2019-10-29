using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.WebUI.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<TodoListViewModel> TodoList { get; set; }
    }
}
