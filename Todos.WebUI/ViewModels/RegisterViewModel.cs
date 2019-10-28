﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Confirm password does not match, try again")]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
    }
}
