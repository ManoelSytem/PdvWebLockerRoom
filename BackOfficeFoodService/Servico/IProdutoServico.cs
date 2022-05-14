using BackOfficeFoodService.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface IProdutoServico
    {
        [Post("/Produto/Create")]
        Task<ActionResultado> Post(ProdutoModel produtoModel);
        [Get("/Produto/GetListProduto")]
        Task<List<ProdutoModel>> GetListProdutoPorCliente(string cliente);
        [Post("/Produto/GetListProdutoPorListaProduto")]
        Task<List<ProdutoModel>> GetListProdutoPorListProduto(List<int> listProduto);
        [Get("/Produto/ObterProduto")]
        Task<ProdutoModel> GetProduto(int id);
        [Get("/Produto/VerificaProdutoEmMenu")]
        Task<ActionResultado> VerificaProdutoMenu(int id, string cliente);
        [Delete("/Produto/DeleteProdutoCliente")]
        Task<ActionResultado> DeleteProdutoPorCliente(int id, string cliente);
        [Post("/Produto/Edit")]
        Task<ActionResultado> Edicao(int codProdutoAnterior, ProdutoModel produtoModel);


    }
}
