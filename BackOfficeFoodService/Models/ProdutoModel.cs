using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class ProdutoModel
    {
        public int codigo { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(100, ErrorMessage = "O nome não deve exceder {1} caractere.")]
        [Display(Name = "Nome do produto")]
        public string nome { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public string valorDecimal { get; set; }
        public string cliente { get; set; }

        public static List<int> ObterListaIdProduto(List<MenuModel> listaCardapio)
        {
            List<int> listProduto = new List<int>();
            foreach (MenuModel lc in listaCardapio)
            {
                listProduto.Add(Convert.ToInt32(lc.codProduto));
            }

            return listProduto;
        }
    }
    
}
