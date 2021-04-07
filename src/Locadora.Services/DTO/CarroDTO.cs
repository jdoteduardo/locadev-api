using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.DTO
{
    public class CarroDTO
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public bool Ativo { get; set; }

        public CarroDTO()
        { }

        public CarroDTO(long id, string placa, int ano, string modelo, string marca, bool ativo)
        {
            Id = id;
            Placa = placa;
            Ano = ano;
            Modelo = modelo;
            Marca = marca;
            Ativo = ativo;
        }
    }
}
