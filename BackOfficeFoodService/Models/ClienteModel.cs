using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "Informe o nome do estabelecimento.")]
        [StringLength(100, ErrorMessage = "O nome não deve exceder {1} caractere.")]
        [Display(Name = "Nome do Food Service")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Informe a descrição.")]
        [StringLength(250, ErrorMessage = "A descrição não deve exceder {1} caractere.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "Informe o endereço.")]
        [StringLength(100, ErrorMessage = "A endereço não deve exceder {1} caractere.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [Required(ErrorMessage = "Informe o contato.")]
        [StringLength(11, ErrorMessage = "O contato dever possuir {1} dígitos.")]
        [Display(Name = "Contato")]
        public string contato { get; set; }
        [EmailAddress(ErrorMessage = "O endereço de email não é valido.")]
        [Required(ErrorMessage = "Informe o endereço de email.")]
        [Display(Name = "Endereço de email.")]
        public string email { get; set; }
    }
}
