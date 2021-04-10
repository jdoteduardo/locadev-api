using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.API.ViewModels
{
    public class ResultViewModel
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public dynamic Dados { get; set; }
    }
}
