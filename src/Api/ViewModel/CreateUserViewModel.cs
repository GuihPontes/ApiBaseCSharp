using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="O nome é necessario")]
        [MaxLength(80,ErrorMessage = "O nome deve ter no mínimo 80 caracters")]
        [MinLength(3,ErrorMessage = "O nome deve ter no mínimo 3 caracters")]
        public string Name { get; set; }



        [Required(ErrorMessage ="O email é obrigatorio")]
        [MaxLength(30, ErrorMessage = "O email deve ter no mínimo 180 caracters")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracters")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage ="A senha é obrigatoria")]
        [MaxLength(30, ErrorMessage = "A senha deve ter no mínimo 30 caracters")]
        [MinLength(6, ErrorMessage = " A senha deve ter no mínimo 6 caracters")]
        
        public string Password { get; set; }

    }
}
