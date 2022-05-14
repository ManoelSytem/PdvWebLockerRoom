using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServiceApi.Model
{
    public class MenuModel
    {
        public int codigoCardapio { get; set; }
        public string codMenuSeq { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int codProduto { get; set; }
        public List<int> ListCodProduto { get; set; }
    }
}
