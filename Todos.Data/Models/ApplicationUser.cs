using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todos.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public virtual IEnumerable<TodoList> TodoList { get; set; }
    }
}
