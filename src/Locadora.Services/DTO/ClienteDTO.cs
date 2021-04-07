using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.DTO
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Contato { get; private set; }

        public ClienteDTO()
        { }

        public ClienteDTO(string nomeCompleto, string cpf, string email, string contato)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Email = email;
            Contato = contato;
        }
    }
}
