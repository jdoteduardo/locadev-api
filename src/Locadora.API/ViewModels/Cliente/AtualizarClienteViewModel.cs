using Locadora.API.ViewModels.Aluguel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.API.ViewModels.Cliente
{
    public class AtualizarClienteViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O ID não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome completo não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome completo deve ter no mínimo 3 caracteres.")]
        [MaxLength(60, ErrorMessage = "O nome completo deve ter no máximo 160 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser vazio.")]
        [MaxLength(14, ErrorMessage = "O campo deve ter no máximo 14 caracteres.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF informado está no formato errado.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email informado está no formato errado.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O contato não pode ser vazio.")]
        [MaxLength(14, ErrorMessage = "O campo deve ter no máximo 14 caracteres.")]
        [RegularExpression(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$", ErrorMessage = "O contato errado está no formato errado.")]
        public string Contato { get; set; }

        [JsonIgnore]
        public List<CriarAluguelViewModel> Alugueis { get; set; }
    }
}
