using Locadora.Core.Exceptions;
using Locadora.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entities
{
    public class Aluguel : Base
    {
        public long IdCarro { get; private set; }
        public Carro Carro { get; private set; }
        public long IdCliente { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime DataAluguel { get; private set; }
        public decimal Valor { get; private set; }

        //EF
        protected Aluguel() { }

        public Aluguel(int idCarro, Carro carro, int idCliente, Cliente cliente, decimal valor)
        {
            IdCarro = idCarro;
            Carro = carro;
            IdCliente = idCliente;
            Cliente = cliente;
            DataAluguel = DateTime.Now;
            Valor = valor;
            _errors = new List<string>();

            Validate();
        }

        public void AlterarValor(decimal valor)
        {
            Valor = valor;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new AluguelValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os.", _errors);
            }

            return true;
        }
    }
}