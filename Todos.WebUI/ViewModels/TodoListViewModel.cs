using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Data.Models;

namespace Todos.WebUI.ViewModels
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
