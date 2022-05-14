using Aplication.Servico;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Negocio
{
    public class ProdutoNegocio
    {
        public ProdutoNegocio()
        {

        }

        public void VerificaListaDeProdutoExiste(List<int> listProduto)
        {
            int codProduto = 0;
            try
            {
                ProdutoService produtodoService = new ProdutoService();
                foreach (int codProd in listProduto)
                {
                    codProduto = codProd;
                    produtodoService.ObterProdutoPorId(codProd);
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
                        return " Este produto esta associado aos seguintes Menu cardápio: " + cardapio;
                    }else if(listProduto.Count == 1)
                    {
                       return " Este produto esta associado ao seguinte Menu cardápio: " + cardapio;
                    }

                }

                return "Produto não esta associado a nenhum Menu cardápio.";

            }
            catch (Exception e)
            {
                throw new NotImplementedException("Falha ao Verificar Produto menu, contatar adiministrador");
            }
        }

    }
}
