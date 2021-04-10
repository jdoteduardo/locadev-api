using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.API.ViewModels.Carro
{
    public class AtualizarCarroViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O ID não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "A placa não pode ser vazio.")]
        [StringLength(7, ErrorMessage = "A placa deve conter 7 caracteres.")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}", ErrorMessage = "A placa informada não é válida.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O ano não pode ser vazio.")]
        [Range(1900, 2100, ErrorMessage = "Ano não é válido")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O modelo não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O modelo deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "A marca deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "A marca deve ter no máximo 50 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Data do registramento não pode ser vazia.")]
        public DateTime RegistradoEm { get; set; }
    }
}
