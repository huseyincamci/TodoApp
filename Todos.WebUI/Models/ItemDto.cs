using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.WebUI.Models
{
    public class ItemDto
    {
        public int TodoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime  Deadline { get; set; }
        public bool Status { get; set; }
    }
}
