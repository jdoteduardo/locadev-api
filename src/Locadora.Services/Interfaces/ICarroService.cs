using Locadora.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.Interfaces
{
    public interface ICarroService
    {
        Task<CarroDTO> Criar(CarroDTO carroDTO);
        Task<CarroDTO> Atualizar(CarroDTO carroDTO);
        Task Cancelar(long id);
        Task<CarroDTO> ObterPorId(long id);
        Task<List<CarroDTO>> ObterTodos();
        Task<List<CarroDTO>> PesquisarPorModelo(string modelo);
        Task<CarroDTO> ObterPorModelo(string modelo);
        Task<CarroDTO> ObterPorMarca(string marca);
        Task<CarroDTO> ObterPorAno(int ano);
    }
}
