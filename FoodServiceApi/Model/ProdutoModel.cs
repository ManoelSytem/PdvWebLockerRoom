using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodServiceApi.Model
{
    public class ProdutoModel
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public Decimal valor { get; set; }
        public string cliente { get; set; }
    }
}
