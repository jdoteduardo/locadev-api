using AutoMapper;
using Locadora.API.Utilities;
using Locadora.API.ViewModels.Carro;
using Locadora.API.ViewModels;
using Locadora.Core.Exceptions;
using Locadora.Services.DTO;
using Locadora.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Locadora.API.Controllers
{
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly IMapper _mapper;

        public CarroController(ICarroService carroService, IMapper mapper)
        {
            _carroService = carroService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/carros/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarCarroViewModel carroViewModel)
        {
            try
            {
                var carroDTO = _mapper.Map<CarroDTO>(carroViewModel);

                var criarCarro = await _carroService.Criar(carroDTO);

                return Ok(new ResultViewModel {
                    Mensagem = "Carro criado com sucesso!",
                    Sucesso = true,
                    Dados = criarCarro
                });
            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {

                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/carros/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCarroViewModel carroViewModel)
        {
            try
            {
                var carroDTO = _mapper.Map<CarroDTO>(carroViewModel);

                var carroAtualizar = await _carroService.Atualizar(carroDTO);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Carro atualizado com sucesso!",
                    Sucesso = true,
                    Dados = carroAtualizar
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/carros/remover/{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            try
            {
                await _carroService.Remover(id);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Carro não está mais disponível.",
                    Sucesso = true,
                    Dados = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/carros/obter/{id}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            try
            {
                var user = await _carroService.ObterPorId(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum carro foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = user
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Carro encontrado com sucesso!",
                    Sucesso = true,
                    Dados = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/carros/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todosCarros = await _carroService.ObterTodos();

                return Ok(new ResultViewModel
                {
                    Mensagem = "Carros encontrados com sucesso!",
                    Sucesso = true,
                    Dados = todosCarros
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/carros/obter-por-marca")]
        public async Task<IActionResult> ObterPorMarca([FromQuery] string marca)
        {
            try
            {
                var marcas = await _carroService.ObterPorMarca(marca);

                if (marcas == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum carro foi encontrado com a marca informada.",
                        Sucesso = true,
                        Dados = marcas
                    });


                return Ok(new ResultViewModel
                {
                    Mensagem = "Carro encontrado com sucesso!",
                    Sucesso = true,
                    Dados = marcas
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/carros/obter-por-modelo")]
        public async Task<IActionResult> ObterPorModelo([FromQuery] string modelo)
        {
            try
            {
                var modelos = await _carroService.ObterPorModelo(modelo);

                if (modelos == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum modelo foi encontrado com o nome informado",
                        Sucesso = true,
                        Dados = modelos
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Modelo encontrado com sucesso!",
                    Sucesso = true,
                    Dados = modelos
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/carros/obter-por-ano")]
        public async Task<IActionResult> SearchByEmail([FromQuery] int ano)
        {
            try
            {
                var anoCarro = await _carroService.ObterPorAno(ano);

                if (anoCarro == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum carro foi encontrado com o ano informado",
                        Sucesso = true,
                        Dados = anoCarro
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = $"Carro(s) fabricado em {ano} encontrado com sucesso!",
                    Sucesso = true,
                    Dados = anoCarro
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
