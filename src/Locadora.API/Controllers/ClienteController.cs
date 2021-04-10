using AutoMapper;
using Locadora.API.Utilities;
using Locadora.API.ViewModels;
using Locadora.API.ViewModels.Cliente;
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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/clientes/criar")]
        public async Task<IActionResult> Criar([FromBody] CriarClienteViewModel clienteViewModel)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClienteDTO>(clienteViewModel);

                var criarCliente = await _clienteService.Criar(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Cliente criado com sucesso!",
                    Sucesso = true,
                    Dados = criarCliente
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
        //[Authorize]
        [Route("/api/v1/clientes/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarClienteViewModel clienteViewModel)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClienteDTO>(clienteViewModel);

                var carroAtualizar = await _clienteService.Atualizar(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Mensagem = "Cliente atualizado com sucesso!",
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

        [HttpGet]
        //[Authorize]
        [Route("/api/v1/clientes/obter/{id}")]
        public async Task<IActionResult> ObterPorId(long id)
        {
            try
            {
                var user = await _clienteService.ObterPorId(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum cliente foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = user
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Cliente encontrado com sucesso!",
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
        //[Authorize]
        [Route("/api/v1/clientes/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var todosCarros = await _clienteService.ObterTodos();

                return Ok(new ResultViewModel
                {
                    Mensagem = "Clientes encontrados com sucesso!",
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
        //[Authorize]
        [Route("/api/v1/clientes/obter-por-nome")]
        public async Task<IActionResult> ObterPorNome(string nomeCompleto)
        {
            try
            {
                var user = await _clienteService.ObterPorNome(nomeCompleto);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum cliente foi encontrado com o nome informado.",
                        Sucesso = true,
                        Dados = user
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Cliente encontrado com sucesso!",
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
        //[Authorize]
        [Route("/api/v1/clientes/obter-por-email")]
        public async Task<IActionResult> ObterPorEmail(string email)
        {
            try
            {
                var user = await _clienteService.ObterPorEmail(email);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum email foi encontrado com o nome informado.",
                        Sucesso = true,
                        Dados = user
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Email encontrado com sucesso!",
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
        //[Authorize]
        [Route("/api/v1/users/pesquisar-por-name")]
        public async Task<IActionResult> PesquisarPorEmail([FromQuery] string email)
        {
            try
            {
                var emails = await _clienteService.PesquisarPorEmail(email);

                if (emails.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Mensagem = "Nenhum cliente foi encontrado com o email informado",
                        Sucesso = true,
                        Dados = null
                    });

                return Ok(new ResultViewModel
                {
                    Mensagem = "Cliente encontrado com sucesso!",
                    Sucesso = true,
                    Dados = emails
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
