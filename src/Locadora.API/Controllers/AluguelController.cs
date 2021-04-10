using AutoMapper;
using Locadora.API.Utilities;
using Locadora.API.ViewModels;
using Locadora.API.ViewModels.Aluguel;
using Locadora.Core.Exceptions;
using Locadora.Services.DTO;
using Locadora.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.API.Controllers
{
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _aluguelService;
        private readonly IMapper _mapper;

        public AluguelController(IAluguelService aluguelService, IMapper mapper, ICarroService carroService = null, IClienteService clienteService = null)
        {
            _aluguelService = aluguelService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/alugueis/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarAluguelViewModel aluguelViewModel)
        {
            try
            {
                var aluguelDTO = _mapper.Map<AluguelDTO>(aluguelViewModel);

                
                var criarCarro = await _aluguelService.Criar(aluguelDTO);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Aluguel registrado com sucesso!",
                    Sucesso = true,
                    Dados = criarCarro
                });
            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
        }

        [HttpPut]
        //[Authorize]
        [Route("/api/v1/alugueis/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarAluguelViewModel aluguelViewModel)
        {
            try
            {
                var aluguelDTO = _mapper.Map<AluguelDTO>(aluguelViewModel);

                var aluguelAtualizar = await _aluguelService.Atualizar(aluguelDTO);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Aluguel atualizado com sucesso!",
                    Sucesso = true,
                    Dados = aluguelAtualizar
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

        [HttpGet]
        //[Authorize]
        [Route("/api/v1/alugueis/obter/{id}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            try
            {
                var aluguel = await _aluguelService.ObterPorId(id);

                if (aluguel == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum aluguel foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = aluguel
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Aluguel encontrado com sucesso!",
                    Sucesso = true,
                    Dados = aluguel
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
        //[Authorize]
        [Route("/api/v1/alugueis/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todosAlugueis = await _aluguelService.ObterTodos();

                return Ok(new ResultViewModel
                {
                    Mensagem = "Alugueis encontrados com sucesso!",
                    Sucesso = true,
                    Dados = todosAlugueis
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
