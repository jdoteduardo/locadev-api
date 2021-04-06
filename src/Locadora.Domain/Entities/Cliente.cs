using Locadora.Domain.Validators;
using System;

namespace Locadora.Domain.Entities
{
    public class Cliente : Base
    {
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Contato { get; private set; }

        public Cliente(string nomeCompleto, string cpf, string email, string contato) 
        {
            this.NomeCompleto = nomeCompleto;
            this.Cpf = cpf;
            this.Email = email;
            this.Contato = contato;
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

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os." + _errors[0]);
            }

            return true;
        }
    }
}