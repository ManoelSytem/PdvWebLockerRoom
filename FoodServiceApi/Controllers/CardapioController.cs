using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Aplication.Interface;
using Aplication.Model;
using Aplication.Negocio;
using Aplication.Repository;
using Aplication.Servico;
using Aplication.Util;
using Dominio;
using FoodServiceApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly IJsonAutoMapper _JsonAutoMapper;
        private readonly CardapioService _CardapioService;
        private readonly ProdutoItemRepository _ProdutoItemRepository;

        public CardapioController(IJsonAutoMapper JsonAutoMapper)
        {
            _JsonAutoMapper = JsonAutoMapper;
            _CardapioService = new CardapioService();
            _ProdutoItemRepository = new ProdutoItemRepository();
        }
        // GET: api/<CardapioController>
        [HttpGet]
        [Route("GetListCardapio")]
        public List<CardapioModel> Get(string cliente)
        {
            var listCardapio = _CardapioService.Listar(cliente);
            var listCardapioModel = _JsonAutoMapper.ConvertAutoMapperListJson<CardapioModel>(listCardapio);
            return listCardapioModel;
        }

        // GET api/<CardapioController>/5
        [HttpGet]
        [Route("ObterCardapioPorId")]
        public CardapioModel ObterCardapioPorId(int id)
        {
            var Cardapio = _CardapioService.GetById(id);
            var CardapioModel = _JsonAutoMapper.ConvertAutoMapperJson<CardapioModel>(Cardapio);
            return CardapioModel;
        }

        [HttpGet]
        [Route("ObterCardapioPrincipal")]
        public CardapioModel ObterCardapioPrincipal()
        {
            var Cardapio = _CardapioService.ObterCardapioPrincipal();
            var CardapioModel = _JsonAutoMapper.ConvertAutoMapperJson<CardapioModel>(Cardapio);
            return CardapioModel;
        }

        // POST api/<CardapioController>
        [Route("Create")]
        [HttpPost]
        public ActionResultado Post(CardapioModel cardapioModel)
        {
            try
            {
                Cardapio novoCarpio = _JsonAutoMapper.ConvertAutoMapperJson<Cardapio>(cardapioModel);
                _CardapioService.Adicionar(novoCarpio);
                return _JsonAutoMapper.Resposta("Cardapio criado com sucesso!");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [HttpPost]
        [Route("CreateListaCardapio")]
        public ActionResultado AddListaItemProduto(MenuModel cardapioMenu)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                CardapoNegocio cardapioNegocio = new CardapoNegocio();

                produtoNegocio.VerificaListaDeProdutoExiste(cardapioMenu.ListCodProduto);

                var listMenuCardapio = cardapioNegocio.MontarListaMenuCardapio(cardapioMenu.codigoCardapio, cardapioMenu.titulo, cardapioMenu.descricao, cardapioMenu.ListCodProduto);
                cardapioNegocio.VerificaProdutoAdicionadoMenuLista(listMenuCardapio);

                var codMenuSeq = _ProdutoItemRepository.GerarcodMenuSeq();
                foreach (ListaItemProduto item in listMenuCardapio)
                {
                    item.codMenuSeq = codMenuSeq;
                    _CardapioService.CriarListaCardapio(item);
                }

                return _JsonAutoMapper.Resposta("Lista de cardápio criado com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");
        }

        [HttpDelete]
        [Route("DeleteListMenu")]
        public ActionResultado DeleteMenuLista(string codMenuSeq)
        {
            try
            {
                _ProdutoItemRepository.Delete(codMenuSeq);
                return _JsonAutoMapper.Resposta("Exclusão do menu realizado com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

        }

        [HttpPost]
        [Route("UpdateListMenu")]
        public ActionResultado UpdateListMenu(MenuModel cardapioMenu)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                CardapoNegocio cardapioNegocio = new CardapoNegocio();

                produtoNegocio.VerificaListaDeProdutoExiste(cardapioMenu.ListCodProduto);
                _ProdutoItemRepository.Delete(cardapioMenu.codMenuSeq);
                var listMenuCardapio = cardapioNegocio.MontarListaMenuCardapio(cardapioMenu.codigoCardapio, cardapioMenu.titulo, cardapioMenu.descricao, cardapioMenu.ListCodProduto);
                cardapioNegocio.VerificaProdutoAdicionadoMenuLista(listMenuCardapio);
            
                foreach (ListaItemProduto item in listMenuCardapio)
                {
                    item.codMenuSeq = cardapioMenu.codMenuSeq;
                    _CardapioService.CriarListaCardapio(item);
                }
                _ProdutoItemRepository.Update(cardapioMenu.codMenuSeq);
                return _JsonAutoMapper.Resposta("Menu atualizado com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");

        }

        [HttpGet]
        [Route("GetListMenuCardapioPorId")]
        public List<MenuModel> GetListMenu(int idCardapio)
        {
            var listaMenuCardapio = _CardapioService.ObterListaMenuCardapioPorId(idCardapio);
            var listMenuCardapioModel = _JsonAutoMapper.ConvertAutoMapperListJson<MenuModel>(listaMenuCardapio);
            return listMenuCardapioModel;
        }

        [HttpGet]
        [Route("GetCardapioPrincipalMenu")]
        public List<MenuModel> GetCardapioPrincipalMenu()
        {
            var cardapioPrincipal = _CardapioService.ObterCardapioPrincipal();
            var listaMenuCardapio = _CardapioService.ObterListaMenuCardapioPorId(cardapioPrincipal.idCardapio).Distinct();
            var listMenuCardapioModel = _JsonAutoMapper.ConvertAutoMapperListJson<MenuModel>(listaMenuCardapio);
            return listMenuCardapioModel;
        }

        [HttpGet]
        [Route("GetMenuPorMenuSeq")]
        public List<MenuModel> GetMenuPorMenuSeq(string codSeqMenu)
        {
            var MenuCardapio = _CardapioService.ObterMenuPorCodMenuSeq(codSeqMenu);
            var MenuCardapioModel = _JsonAutoMapper.ConvertAutoMapperListJson<MenuModel>(MenuCardapio);
            return MenuCardapioModel;
        }


        // DELETE api/<CardapioController>/5
        [HttpDelete]
        [Route("DeleteCardapio")]
        public ActionResultado Delete(int id, string cliente)
        {
            try
            {
              
                var listaDeMenuCliente = _ProdutoItemRepository.ObterListaMenuAssociadoCardapio(id, cliente);
                _CardapioService.Excluir(id);
                _ProdutoItemRepository.DeleteProdutoAssociadoALista(listaDeMenuCliente);
                return _JsonAutoMapper.Resposta("Exclusão do menu realizado com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }


        [HttpPut]
        [Route("AtualizaCardapio")]
        public ActionResultado AtualizaCardapio(int id, string titulo)
        {
            try
            {
                var cardapio = _CardapioService.GetById(id);
                cardapio.titulo = titulo;
                cardapio.update = "1";
                _CardapioService.Alterar(cardapio);
                return _JsonAutoMapper.Resposta("Atualização realizada com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [HttpPost]
        [Route("DefinirCardapioPrincipal")]
        public ActionResultado DefinirCardapioPrincipal(int codCardapio)
        {
            try
            {
                _CardapioService.DefenirCardapioPrincipal(codCardapio);
                return _JsonAutoMapper.Resposta("Cardápio definido príncipal com sucesso!");

            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }
    }
}
