using Aplication.Interface;
using Aplication.Repository;
using Dominio;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Aplication.Servico
{
    public class CardapioService : IDisposable, ICardapio
    {
        UnitOfWork _uow;
        public CardapioService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public CardapioService()
        {
            _uow  = new UnitOfWork();
        }
        public IEnumerable<Cardapio> Listar()
        {
            return _uow.CardapioRepository.Get();
        } 
        public void Adicionar(Cardapio card)
        {
            _uow.CardapioRepository.Add(card);
            _uow.Commit();
        }
        public void CriarListaCardapio(ListaItemProduto listaItemProduto)
        {
            _uow.ProdutoItemRepository.Add(listaItemProduto);
            _uow.Commit();
        }
        public IEnumerable<ListaItemProduto> ObterListaMenuCardapioPorId(int IdCardapio)
        {
            return _uow.ProdutoItemRepository.Get(p => p.codigoCardapio == IdCardapio && p.delete != "1");
        }


        public IEnumerable<ListaItemProduto> ObterMenuPorCodMenuSeq(string codMenuSeq)
        {
            return _uow.ProdutoItemRepository.Get(p => p.codMenuSeq == codMenuSeq && p.delete != "1");
        }

        public void Excluir(int id)
        {
            var cardapio = _uow.CardapioRepository.Get(x => x.idCardapio == id).Single();
            cardapio.delete = "1";
            _uow.CardapioRepository.Update(cardapio);
            _uow.Commit();
        }
        public void Alterar(Cardapio card)
        {
            _uow.CardapioRepository.Update(card);
            _uow.Commit();
        }
        public IEnumerable<Cardapio> Listar(string cliente)
        {
            return _uow.CardapioRepository.Get(c => c.idUser == cliente && c.delete != "1");
        }

        public Cardapio GetById(int id)
        {
            return _uow.CardapioRepository.GetById(c => c.idCardapio == id);
        }

        public Cardapio ObterCardapioPrincipal()
        {
            return _uow.CardapioRepository.GetByIdFind(c => c.ePrincipal == "S" &&  c.delete != "1");
        }


        public void Dispose()
        {
            _uow.Dispose();
        }

        public ListaItemProduto ObterItemMenu(int codProduto, int codCardapio)
        {
            return _uow.ProdutoItemRepository.GetByIdFind(c => c.codProduto == codProduto && c.codigoCardapio == codCardapio && c.delete != "1");
        }

        public void DefenirCardapioPrincipal(int codCardapio)
        {
            IEnumerable<Cardapio> listCardapio = _uow.CardapioRepository.Get();
            listCardapio.ToList().ForEach(c => c.ePrincipal = "");
            _uow.Commit();

            var cardapio = _uow.CardapioRepository.Get(x => x.idCardapio == codCardapio).Single();
            cardapio.ePrincipal = "S";
            _uow.CardapioRepository.Update(cardapio);
            _uow.Commit();
        }
    }
}
