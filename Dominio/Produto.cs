using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("produto")]
    public class Produto
    { 
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public float valor { get; set; }
        public int quantidade { get; set; }
        public string cliente { get; set; }
        public string delete { get; set; }
        public string update { get; set; }

    }
}
