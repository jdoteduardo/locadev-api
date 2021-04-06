using FluentValidation;
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

        //EF
        protected Carro() { }

        public Carro(string placa, int ano, string modelo, string marca) 
        {
            this.Placa = placa;
            this.Ano = ano;
            this.Modelo = modelo;
            this.Marca = marca;
            _errors = new List<string>();
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

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os." + _errors[0]);
            }

            return true;
        }
    }
}