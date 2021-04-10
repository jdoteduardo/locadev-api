using FluentValidation;
using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Validators
{
    public class AluguelValidator : AbstractValidator<Aluguel>
    {
        public AluguelValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.IdCarro)
                .NotEmpty()
                .WithMessage("O id do carro não pode ser vazio.")

                .NotNull()
                .WithMessage("O id do carro não pode ser nulo.");

            RuleFor(x => x.IdCliente)
                .NotEmpty()
                .WithMessage("O id do cliente não pode ser vazio.")

                .NotNull()
                .WithMessage("O id do cliente não pode ser nulo.");

            RuleFor(x => x.DataAluguel)
                .NotEmpty()
                .WithMessage("A data do aluguel não pode ser vazia.")

                .NotNull()
                .WithMessage("A data do aluguel não pode ser nula.");

            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor não pode ser vazio.")

                .NotNull()
                .WithMessage("O valor não pode ser nulo.");
        }
    }
}
