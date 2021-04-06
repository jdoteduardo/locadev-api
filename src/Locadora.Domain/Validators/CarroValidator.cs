using FluentValidation;
using Locadora.Domain.Entities;

namespace Locadora.Domain.Validators
{
    public class CarroValidator : AbstractValidator<Carro>
    {
        public CarroValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Placa)
                .NotEmpty()
                .WithMessage("A placa não pode ser vazia.")
                
                .NotNull()
                .WithMessage("A placa não pode ser nula.")

                .Length(7)
                .WithMessage("A placa deve conter 8 caracteres.")

                .Matches(@"[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}")
                .WithMessage("Placa no formato errado.");

            RuleFor(x => x.Ano)
                .NotEmpty()
                .WithMessage("O ano não pode ser vazio.")
                
                .NotNull()
                .WithMessage("O ano não pode ser nulo.");

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .WithMessage("O modelo não pode ser vazio.")
                
                .NotNull()
                .WithMessage("O modelo não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O modelo deve ter no mínimo 3 caracteres.")

                .MaximumLength(50)
                .WithMessage("O modelo deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Marca)
                .NotEmpty()
                .WithMessage("A marca não pode ser vazio.")
                
                .NotNull()
                .WithMessage("A marca não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("A marca deve ter no mínimo 3 caracteres.")

                .MaximumLength(50)
                .WithMessage("A marca deve ter no máximo 50 caracteres.");
        }
    }
}