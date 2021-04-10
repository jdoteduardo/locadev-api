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
        public string Placa { get; private set; }
        public int Ano { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public CarroStatusEnumDTO Status { get; private set; }
        public DateTime RegistradoEm { get; private set; }

        public CarroDTO()
        { }

        public CarroDTO(string placa, int ano, string marca, string modelo, CarroStatusEnumDTO status, DateTime registradoEm)
        {
            Placa = placa;
            Ano = ano;
            Marca = marca;
            Modelo = modelo;
            Status = status;
            RegistradoEm = registradoEm;
        }
    }
}
