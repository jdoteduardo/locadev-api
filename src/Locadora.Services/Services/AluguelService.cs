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
    public class AluguelService : IAluguelService
    {
        private readonly IMapper _mapper;
        private readonly IAluguelRepository _aluguelRepository;
        private readonly ICarroRepository _carroRepository;

        public AluguelService(IMapper mapper, IAluguelRepository aluguelRepository, ICarroRepository carroRepository, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _aluguelRepository = aluguelRepository;
            _carroRepository = carroRepository;
        }

        public async Task<AluguelDTO> Atualizar(AluguelDTO aluguelDTO)
        {
            var aluguelExiste = await _aluguelRepository.ObterPorId(aluguelDTO.Id);

            if (aluguelExiste != null)
            {
                throw new DomainException("Não existe nenhum usuário com ID informado.");
            }

            var carro = _mapper.Map<Aluguel>(aluguelDTO);
            carro.Validate();

            var attAluguel = await _aluguelRepository.Atualizar(carro);

            return _mapper.Map<AluguelDTO>(attAluguel);
        }

        public async Task<AluguelDTO> Criar(AluguelDTO aluguelDTO)
        {
            var disponiveis = await _carroRepository.ObterDisponiveis();

            if (disponiveis != null)
            {
                throw new DomainException("Carro não está disponível.");
            }

            var aluguel = _mapper.Map<Aluguel>(aluguelDTO);
            aluguel.Validate();

            var criarAluguel = await _aluguelRepository.Criar(aluguel);

            return _mapper.Map<AluguelDTO>(criarAluguel);
        }

        public async Task<AluguelDTO> ObterPorId(long id)
        {
            var idAluguel = await _aluguelRepository.ObterPorId(id);

            return _mapper.Map<AluguelDTO>(idAluguel);
        }

        public async Task<List<AluguelDTO>> ObterTodos()
        {
            var alugueis = await _aluguelRepository.ObterTodos();

            return _mapper.Map<List<AluguelDTO>>(alugueis);
        }

        public async Task Remove(long id)
        {
            await _aluguelRepository.Remover(id);
        }
    }
}
