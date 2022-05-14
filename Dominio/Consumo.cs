using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("consumo")]
    public class Consumo
    {
        [Key]
        public int codigo { get; set; }
        public string codMesa { get; set; }
        public string codProduto { get; set; }
        public string seqAbreMesa { get; set; }
        public DateTime horaPedido { get; set; }
        public string status { get; set; }
        public string delete { get; set; }
    }
}
