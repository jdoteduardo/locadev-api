using Locadora.API.ViewModels.Carro;
using Locadora.API.ViewModels.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.API.ViewModels.Aluguel
{
    public class AtualizarAluguelViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O ID não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O ID do carro não pode ser vazio.")]
        public long IdCarro { get; set; }

        [JsonIgnore]
        public CriarCarroViewModel Carro { get; set; }

        [Required(ErrorMessage = "O ID do cliente não pode ser vazio.")]
        public long IdCliente { get; set; }

        [JsonIgnore]
        public CriarClienteViewModel Cliente { get; set; }

        [Required(ErrorMessage = "A data de aluguel não pode ser vazio.")]
        public DateTime DataAluguel { get; set; }

        [Required(ErrorMessage = "O valor não pode ser vazio.")]
        public decimal Valor { get; set; }
    }
}
