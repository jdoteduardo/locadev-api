using FluentValidation;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia.")

            .NotNull()
            .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .WithMessage("O nome completo não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome completo não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O nome completo deve ter no mínimo 3 caracteres.")

                .MaximumLength(160)
                .WithMessage("O nome completo deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O CPF não pode ser vazia.")

                .NotNull()
                .WithMessage("O CPF não pode ser nula.")

                .MaximumLength(14)
                .WithMessage("O campo deve conter no máximo 14 caracteres.")

                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                .WithMessage("CPF no formato errado.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(x => x.Contato)
                .NotNull()
                .WithMessage("O contato não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O contato não pode ser vazio.")

                .MaximumLength(15)
                .WithMessage("O campo deve conter no máximo 15 caracteres.")

                .Matches(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$")
                .WithMessage("O contato informado não é válido.");
        }
    }
}