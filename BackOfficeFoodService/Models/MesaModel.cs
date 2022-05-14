using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class MesaModel
    {
        public int codigo { get; set; } 
        [Display(Name = "Número da mesa")]
        [Required(ErrorMessage = "Informe o número da mesa.")]
        public int numero { get; set; }
        public string status { get; set; }
        public string seqAbreMesa { get; set; }

    }
}
