using FluentValidation;
using Locadora.Core.Exceptions;
using Locadora.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entities
{
    public class Carro : Base
    {
        public string Placa { get; private set; }
        public int Ano { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public CarroStatusEnum Status { get; private set; }
        public DateTime RegistradoEm { get; private set; }

        //EF
        protected Carro() { }

        public Carro(string placa, int ano, string modelo, string marca) 
        {
            Placa = placa;
            Ano = ano;
            Modelo = modelo;
            Marca = marca;
            Status = CarroStatusEnum.Disponivel;
            RegistradoEm = DateTime.Now;
            _errors = new List<string>();

            Validate();
        }

        public void Atualizar(int ano)
        {
            Ano = ano;
        }

        public void RetirarCarro()
        {
            Status = CarroStatusEnum.Indisponivel;
        }

        public override bool Validate()
        {
            var validator = new CarroValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
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