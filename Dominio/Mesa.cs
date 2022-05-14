using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    [Table("mesa")]
    public class Mesa
    {
         [Key]
         public int codigo { get; set; }
         public  int numero { get; set; }
         public string status { get; set; }
         public string seqAbreMesa { get; set; }
    }
}
