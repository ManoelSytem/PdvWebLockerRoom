using Aplication.Servico;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Negocio
{
    public class ProdutoNegocio
    {
        private readonly ProdutoService _ProdutoService;
        public ProdutoNegocio(ProdutoService produtoService)
        {
            _ProdutoService = produtoService;
        }

        public void VerificaListaDeProdutoExiste(List<int> listProduto)
        {
            int codProduto = 0;
            try
            {
                foreach (int codProd in listProduto)
                {
                    codProduto = codProd;
                    _ProdutoService.ObterProdutoPorId(codProd);
                }

            }
            catch (Exception e)
            {
                throw new NotImplementedException("Produto não encontrado, código: " + codProduto);
            }
        }

        public string VerificaSeProdutoExisteMenu(List<ListaItemProduto> listProduto)
        {
            string cardapio = "";
            try
            {
                if (listProduto.Count > 0)
                {

                    foreach (ListaItemProduto item in listProduto)
                    {
                        cardapio += item.titulo + ";";
                    }

                    if (listProduto.Count > 1)
                    {
                        return "Este produto não esta associado nenhuma categoria no estoque: " + cardapio;
                    }else if(listProduto.Count == 1)
                    {
                       return "Este produto esta associado a seguinte categoria no estoque: " + cardapio;
                    }

                }

                return "Produto não esta associado a nenhuma categoria no estoque.";

            }
            catch (Exception e)
            {
                throw new NotImplementedException("Falha ao Verificar Produto cetegoria, contatar Analista desenvolvedor");
            }
        }

        public void VerificaQuantidadeProdutoEstoque(string codProduto)
        {
            var produto = _ProdutoService.ObterProdutoPorId(Convert.ToInt32(codProduto));

                if (produto.quantidade == 0)
                {
                    throw new NotImplementedException("Produto esta em falta no estoque. Verifique a quantidade.");
                }
        }

    }
}
