using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.DTO
{
    public class AluguelDTO
    {
        public long Id { get; set; }
        public long IdCarro { get; set; }
        public CarroDTO Carro { get; set; }
        public long IdCliente { get; set; }
        public ClienteDTO Cliente { get; set; }
        public DateTime DataAluguel { get; set; }
        public decimal Valor { get; set; }

        public AluguelDTO()
        { }

        public AluguelDTO(long idCarro, CarroDTO carro, long idCliente, ClienteDTO cliente, decimal valor)
        {
            IdCarro = idCarro;
            Carro = carro;
            IdCliente = idCliente;
            Cliente = cliente;
            DataAluguel = DateTime.Now;
            Valor = valor;
        }
    }
}
