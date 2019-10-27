using System;
using System.Collections.Generic;
using System.Text;

namespace Todos.Data.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}
