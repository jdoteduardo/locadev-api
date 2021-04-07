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
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public bool Ativo { get; set; }

        //EF
        protected Carro() { }

        public Carro(string placa, int ano, string modelo, string marca, bool ativo) 
        {
            Placa = placa;
            Ano = ano;
            Modelo = modelo;
            Marca = marca;
            Ativo = ativo;
            _errors = new List<string>();

            Validate();
        }

        public void AlterarPlaca(string placa)
        {
            Placa = placa;
            Validate();
        }
        
        public void AlterarAno(int ano)
        {
            Ano = ano;
            Validate();
        }

        public void AlterarModelo(string modelo)
        {
            Modelo = modelo;
            Validate();
        }

        public void AlterarMarca(string marca)
        {
            Marca = marca;
            Validate();
        }

        public void AlterarAtivo(bool ativo)
        {
            Ativo = ativo;
            Validate();
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