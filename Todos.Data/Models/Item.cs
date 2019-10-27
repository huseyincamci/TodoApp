using System;
using System.Collections.Generic;
using System.Text;

namespace Todos.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }

        public virtual TodoList Todos { get; set; }
    }
}
