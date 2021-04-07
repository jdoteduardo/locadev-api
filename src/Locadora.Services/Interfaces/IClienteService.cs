using Locadora.Domain.Entities;
using Locadora.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> Criar(ClienteDTO clienteDTO);
        Task<ClienteDTO> Atualizar(ClienteDTO clienteDTO);
        Task Cancelar(long id);
        Task<ClienteDTO> ObterPorId(long id);
        Task<List<ClienteDTO>> ObterTodos();
        Task<ClienteDTO> ObterPorNome(string nomeCompleto);
        Task<ClienteDTO> ObterPorEmail(string email);
        Task<List<ClienteDTO>> PesquisarPorEmail(string email);
    }
}
