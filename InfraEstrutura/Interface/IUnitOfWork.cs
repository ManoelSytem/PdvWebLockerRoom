using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraEstrutura.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Cardapio> CardapioRepository { get; }
        IRepository<Cliente> ClienteRepository { get; }
        IRepository<Produto> ProdutoRepository { get; }
        IRepository<ListaItemProduto> ProdutoItemRepository { get; }
       
        void Commit();
    }
}
