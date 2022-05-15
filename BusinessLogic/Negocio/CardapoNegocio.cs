using Aplication.Servico;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Negocio
{
    public class CardapoNegocio
    {
        private readonly CardapioService _CardapioService;
        public CardapoNegocio(CardapioService _cardapioService)
        {
            _CardapioService = _cardapioService;
        }

        public List<ListaItemProduto> MontarListaMenuCardapio(int idCardapio, string titulo, string descricao, List<int> listCodProduto)
        {
            List<ListaItemProduto> novaLista = new List<ListaItemProduto>();

            foreach(int idProduto in listCodProduto)
            {
                var listModel = new ListaItemProduto
                {
                    codigoCardapio = idCardapio,
                    titulo = titulo,
                    descricao = descricao,
                    codProduto = idProduto
                };
                novaLista.Add(listModel);
            }

            return novaLista;
        }

        public void VerificaProdutoAdicionadoMenuLista(List<ListaItemProduto> ListaMenu)
        {
            try
            {
                foreach (ListaItemProduto menu in ListaMenu)
                {
                    var itemMenu = _CardapioService.ObterItemMenu(menu.codProduto, menu.codigoCardapio);
                    if(itemMenu != null)
                    {
                        throw new NotImplementedException("O Produto de código "+itemMenu.codProduto+", já foi adicionando no menu "+itemMenu.titulo+", favor verificar.");
                    }
;                }

            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
