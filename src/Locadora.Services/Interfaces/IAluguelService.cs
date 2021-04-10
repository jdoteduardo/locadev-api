using Locadora.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.Interfaces
{
    public interface IAluguelService
    {
        Task<AluguelDTO> Criar(AluguelDTO aluguelDTO);
        Task<AluguelDTO> Atualizar(AluguelDTO aluguelDTO);
        Task Remove(long id);
        Task<AluguelDTO> ObterPorId(long id);
        Task<List<AluguelDTO>> ObterTodos();
    }
}
