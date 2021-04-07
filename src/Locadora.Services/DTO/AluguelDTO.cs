using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.DTO
{
    public class AluguelDTO
    {
        public long IdCarro { get; private set; }
        public CarroDTO Carro { get; private set; }
        public long IdCliente { get; private set; }
        public ClienteDTO Cliente { get; private set; }
        public DateTime DataAluguel { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }

        public AluguelDTO()
        { }

        public AluguelDTO(long idCarro, CarroDTO carro, long idCliente, ClienteDTO cliente, DateTime dataAluguel, decimal valor, bool ativo)
        {
            IdCarro = idCarro;
            Carro = carro;
            IdCliente = idCliente;
            Cliente = cliente;
            DataAluguel = dataAluguel;
            Valor = valor;
            Ativo = ativo;
        }
    }
}
