using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ClienteModel
    {
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Informe o nome do cliente.")]
        [StringLength(100, ErrorMessage = "O nome não deve exceder {1} caractere.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Informe o endereço.")]
        [StringLength(100, ErrorMessage = "A endereço não deve exceder {1} caractere.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [Required(ErrorMessage = "Informe o contato.")]
        [StringLength(11, ErrorMessage = "O contato dever possuir {1} dígitos.")]
        [Display(Name = "Contato")]
        public string contato { get; set; }
        public string email { get; set; }
    }
}
