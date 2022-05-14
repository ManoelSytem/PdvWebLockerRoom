using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
    public interface ICardapio
    {
        public void CriarListaCardapio(ListaItemProduto listaItemProduto);
        public ListaItemProduto ObterItemMenu(int codProduto, int codCardapio);

        public void DefenirCardapioPrincipal(int codCardapio);
    }
}
