﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login não pode vazio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Password { get; set; }
    }
}
