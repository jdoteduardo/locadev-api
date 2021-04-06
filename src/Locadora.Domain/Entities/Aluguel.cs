using Locadora.Core.Exceptions;
using Locadora.Domain.Validators;
using System;

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
        public bool Ativo { get; private set; }

        //EF
        protected Aluguel() { }

        public Aluguel(int idCarro, Carro carro, int idCliente, Cliente cliente, DateTime dataAluguel, decimal valor, bool ativo)
        {
            IdCarro = idCarro;
            Carro = carro;
            IdCliente = idCliente;
            Cliente = cliente;
            DataAluguel = dataAluguel;
            Valor = valor;
            Ativo = ativo;
        }

        public void AlterarIdCarro(long idCarro)
        {
            IdCarro = idCarro;
            Validate();
        }

        public void AlterarIdCliente(long idCliente)
        {
            IdCliente = idCliente;
            Validate();
        }

        public void AlterarData(DateTime dataAluguel)
        {
            DataAluguel = dataAluguel;
            Validate();
        }

        public void AlterarValor(decimal valor)
        {
            Valor = valor;
            Validate();
        }

        public void AlterarAtivo(bool ativo)
        {
            Ativo = ativo;
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