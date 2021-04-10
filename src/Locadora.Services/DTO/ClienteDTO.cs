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
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public List<AluguelDTO> Alugueis { get; set; }

        public ClienteDTO()
        { }

        public ClienteDTO(string nomeCompleto, string cpf, string email, string contato, List<AluguelDTO> alugueis)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Email = email;
            Contato = contato;
            Alugueis = alugueis;
        }
    }
}
