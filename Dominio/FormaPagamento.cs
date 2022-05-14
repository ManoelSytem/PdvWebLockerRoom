using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("formapagamento")]
    public class FormaPagamento
    {
        [Key]
        public int codigo { get; set; }
        public string descricao { get; set; }
    }
}
