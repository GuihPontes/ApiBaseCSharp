using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class UpdateViewModel : CreateUserViewModel
    {
        [Required(ErrorMessage ="O id é obrigatorio !")]
        [MinLength(1,ErrorMessage ="O Id não pode ser menor que 1 ")]
        public long Id { get; set; }
    }
}
