using Locadora.Core.Exceptions;
using Locadora.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entities
{
    public class Cliente : Base
    {
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Contato { get; private set; }
        public bool Ativo { get; set; }

        protected Cliente()
        {

        }

        public Cliente(string nomeCompleto, string cpf, string email, string contato) 
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Email = email;
            Contato = contato;
            _errors = new List<string>();

            Validate();
        }

        public void AlterarNomeCompleto(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
            Validate();
        }
        
        public void AlterarCpf(string cpf)
        {
            Cpf = cpf;
            Validate();
        }
        
        public void AlterarEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new ClienteValidator();
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