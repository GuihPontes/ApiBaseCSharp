using Base.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia");

            RuleFor(x => x)
                .NotNull()
                .WithMessage("A entidade não pode ser nula");




            RuleFor(x => x.Name)

                .NotEmpty()
                .WithMessage("O nome não pode ser vazia")

                .NotNull()
                .WithMessage("O nome não pode ser nula")


                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracters")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no mínimo 80 caracters ");




            RuleFor(x => x.Email)

                .NotEmpty()
                .WithMessage("O Email não pode ser vazia")

                .NotNull()
                .WithMessage("O Email não pode ser nula")


                .EmailAddress()
                .WithMessage("Email inválido")

                 .MinimumLength(10)
                .WithMessage("O Email deve ter no mínimo 10 caracters")

                .MaximumLength(180)
                .WithMessage("O Email deve ter no mínimo 180 caracters ")



                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");


            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(80)
                .WithMessage("A senha deve ter no máximo 30 caracteres.");




        }
    }
}
