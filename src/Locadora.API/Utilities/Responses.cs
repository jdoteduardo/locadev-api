﻿using Locadora.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Mensagem = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Sucesso = false,
                Dados = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Mensagem = message,
                Sucesso = false,
                Dados = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Mensagem = message,
                Sucesso = false,
                Dados = errors
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Mensagem = "A combinação de login e senha está incorreta!",
                Sucesso = false,
                Dados = null
            };
        }
    }
}
