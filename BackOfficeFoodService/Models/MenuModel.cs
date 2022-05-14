using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class MenuModel
    {
        public int codigoCardapio { get; set; }
        [Required(ErrorMessage = "Informe o titulo.")]
        [StringLength(100, ErrorMessage = "O nome não deve exceder {1} caractere.")]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }
        public string codMenuSeq { get; set; }
        public string descricao { get; set; }
        public int codProduto { get; set; }
        public List<int> ListCodProduto { get; set; }
        public List<ProdutoModel> ListProduto { get; set; }


        public static List<MenuModel> ObterListaDeMenuComListaDeProduto(List<MenuModel> responseListMenu, List<ProdutoModel> ListProdutoModel)
        {
            var listaDistinc = responseListMenu.GroupBy(i => new MenuModel { titulo = i.titulo, descricao = i.descricao, codMenuSeq = i.codMenuSeq }).Distinct();
            
            List<MenuModel> listaDeMenu = new List<MenuModel>();
            foreach (var item in listaDistinc.ToList())
            {
                var query = from listMenu in responseListMenu
                            join prod in ListProdutoModel on listMenu.codProduto equals prod.codigo
                            where listMenu.titulo == item.Key.titulo
                            select new ProdutoModel()
                            {
                                codigo = prod.codigo,
                                nome = prod.nome,
                                valor = prod.valor
                            
                            };

                item.Key.ListProduto = query.ToList();
                if (!listaDeMenu.Any(x => x.titulo == item.Key.titulo))
                    listaDeMenu.Add(item.Key);

            }

            return listaDeMenu;
        }
    }
}
