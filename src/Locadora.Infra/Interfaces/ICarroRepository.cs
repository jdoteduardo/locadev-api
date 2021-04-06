using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface ICarroRepository : IBaseRepository<Carro>
    {
        Task<Carro> ObterPorMarca(string marca);
        Task<Carro> ObterPorModelo(string modelo);
        Task<List<Carro>> PesquisarPorModelo(string modelo);
        Task<Carro> ObterPorAno(int ano);
    }
}
