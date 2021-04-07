using AutoMapper;
using Locadora.Core.Exceptions;
using Locadora.Domain.Entities;
using Locadora.Infra.Interfaces;
using Locadora.Services.DTO;
using Locadora.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> Atualizar(ClienteDTO clienteDTO)
        {
            var clienteExiste = await _clienteRepository.ObterPorId(clienteDTO.Id);

            if (clienteExiste != null)
            {
                throw new DomainException("Não existe nenhum usuário com ID informado.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente.Validate();

            var attCliente = await _clienteRepository.Atualizar(cliente);

            return _mapper.Map<ClienteDTO>(attCliente);
        }

        public async Task<ClienteDTO> Criar(ClienteDTO clienteDTO)
        {
            if (_clienteRepository.Buscar(f => f.Cpf == clienteDTO.Cpf).Result.Any())
            {
                throw new DomainException("Já existe um fornecedor com este documento informado.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente.Validate();

            var criarCliente = await _clienteRepository.Criar(cliente);

            return _mapper.Map<ClienteDTO>(criarCliente);
        }

        public async Task Cancelar(long id)
        {
            await _clienteRepository.Cancelar(id);
        }

        public async Task<ClienteDTO> ObterPorEmail(string email)
        {
            var emailCliente = await _clienteRepository.ObterPorEmail(email);

            return _mapper.Map<ClienteDTO>(emailCliente);
        }

        public async Task<ClienteDTO> ObterPorId(long id)
        {
            var idCliente = await _clienteRepository.ObterPorId(id);

            return _mapper.Map<ClienteDTO>(idCliente);
        }

        public async Task<ClienteDTO> ObterPorNome(string nomeCompleto)
        {
            var nome = await _clienteRepository.ObterPorNome(nomeCompleto);

            return _mapper.Map<ClienteDTO>(nome);
        }

        public async Task<List<ClienteDTO>> ObterTodos()
        {
            var todosClientes = await _clienteRepository.ObterTodos();

            return _mapper.Map<List<ClienteDTO>>(todosClientes);
        }

        public async Task<List<ClienteDTO>> PesquisarPorEmail(string email)
        {
            var emails = await _clienteRepository.PesquisarPorEmail(email);

            return _mapper.Map<List<ClienteDTO>>(emails);
        }
    }
}
