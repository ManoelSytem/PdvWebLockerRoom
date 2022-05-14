using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("cardapio")]
    public class Cardapio
    {
        [Key]
        public int idCardapio { get; set; }
        public string idUser { get; set; }
        public string titulo { get; set; }
        public string delete { get; set; }
        public string update { get; set; }
        public string ePrincipal { get; set; }

    }
}
