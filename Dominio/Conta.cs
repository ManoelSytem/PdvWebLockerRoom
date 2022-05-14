using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("conta")]
    public class Conta
    {
        [Key]
        public int codigo { get; set; }
        public string seqAbreMesa { get; set; }
        public int numeroMesa { get; set; }
        public decimal total { get; set; }
        public string formaPagamento { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataBaixaConta { get; set; }
        public DateTime dataFechamento { get; set; }
        public decimal valorEntrada { get; set; }
        public decimal valorSaida { get; set; }
        public decimal totalTroco { get; set; }
        public string status { get; set; }

    }
}
