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
    public class CarroService : ICarroService
    {
        private readonly IMapper _mapper;
        private readonly ICarroRepository _carroRepository;

        public CarroService(IMapper mapper, ICarroRepository carroRepository)
        {
            _mapper = mapper;
            _carroRepository = carroRepository;
        }

        public async Task<CarroDTO> Atualizar(CarroDTO carroDTO)
        {
            var carroExiste = await _carroRepository.ObterPorId(carroDTO.Id);

            if (carroExiste != null)
            {
                throw new DomainException("Não existe nenhum usuário com ID informado.");
            }

            var carro = _mapper.Map<Carro>(carroDTO);
            carro.Validate();

            var attCarro = await _carroRepository.Atualizar(carro);

            return _mapper.Map<CarroDTO>(attCarro);
        }

        public async Task<CarroDTO> Criar(CarroDTO carroDTO)
        {
            var carroExiste = await _carroRepository.ObterPorPlaca(carroDTO.Placa);

            if(carroExiste != null)
            {
                throw new DomainException("Já existe um carro com essa placa.");
            }

            var carro = _mapper.Map<Carro>(carroDTO);
            carro.Validate();

            var criarCarro = await _carroRepository.Criar(carro);

            return _mapper.Map<CarroDTO>(criarCarro);
        }

        public async Task<CarroDTO> ObterPorAno(int ano)
        {
            var anoCarro = await _carroRepository.ObterPorAno(ano);

            return _mapper.Map<CarroDTO>(anoCarro);
        }

        public async Task<CarroDTO> ObterPorId(long id)
        {
            var idCarro = await _carroRepository.ObterPorId(id);

            return _mapper.Map<CarroDTO>(idCarro);
        }

        public async Task<CarroDTO> ObterPorMarca(string marca)
        {
            var marcaCarro = await _carroRepository.ObterPorMarca(marca);

            return _mapper.Map<CarroDTO>(marcaCarro);
        }

        public async Task<CarroDTO> ObterPorModelo(string modelo)
        {
            var carro = await _carroRepository.ObterPorModelo(modelo);

            return _mapper.Map<CarroDTO>(carro);
        }

        public async Task<List<CarroDTO>> ObterTodos()
        {
            var todosCarros = await _carroRepository.ObterTodos();

            return _mapper.Map<List<CarroDTO>>(todosCarros);
        }

        public async Task<List<CarroDTO>> PesquisarPorModelo(string modelo)
        {
            var modelosCarros = await _carroRepository.PesquisarPorModelo(modelo);

            return _mapper.Map<List<CarroDTO>>(modelosCarros);
        }

        public async Task Remover(long id)
        {
            await _carroRepository.Remover(id);
        }
    }
}
