using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ConsumoModel
    {
       
        public int codigo { get; set; }
        public string codMesa { get; set; }
        public string codProduto { get; set; }
        public string seqAbreMesa { get; set; }
        public DateTime horaPedido { get; set; }
        public ProdutoModel produto { get; set; }

        public ConsumoModel()
        {

        }

    }
}
