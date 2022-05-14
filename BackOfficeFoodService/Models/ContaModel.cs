using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ContaModel
    {
        public int codigo { get; set; }
        [Required(ErrorMessage = "Informe o número do Pedido para realizar a buscar")]
        [Display(Name = "Número Pedido")]
        public string seqAbreMesa { get; set; }
        public int numeroMesa { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataFechamento { get; set; }
        [Display(Name = "R$ Total a pagar")]
        public decimal total { get; set; }
        [Display(Name = "Forma de Pagamento")]
        public string formaPagamento { get; set; }
        [Display(Name = "Valor Entrada")]
        public decimal valorEntrada { get; set; }
        [Display(Name = "Valor Saída")]
        public decimal valorSaida { get; set; }
        [Display(Name = "Troco")]
        public decimal totalTroco { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }

    }
}
