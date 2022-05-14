using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackOfficeFoodService.Models;
using BackOfficeFoodService.Servico;
using BackOfficeFoodService.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;

namespace BackOfficeFoodService.Controllers
{
    public class CardapioController : ControllerBase
    {
        // GET: CardapioController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: CardapioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CardapioController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                if (AutenticanteVerifiy())
                {
                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                    var result = await ICardapio.GetListCardapioPorCliente(email);
                    var cardapioModel = new CardapioModel
                    {
                        ListCardapio = result
                    };
                    return View(cardapioModel);
                }
                else { return RedirectToAction("index", "login"); }
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> MenuListCardapio(int idCardapio)
        {
            try
            {
                var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var listProdutoCliente = await IProduto.GetListProdutoPorCliente(email);
                var listProdutoPorCardapioCliente = await IProduto.GetListProdutoPorCliente(email);
                ViewBag.ProdutoList = new MultiSelectList(listProdutoCliente, "codigo", "nome");
                return View();
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }

        }

        [HttpGet]
        public async Task<CardapioModel> ObterCardapio(int id)
        {
                var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                var result = await ICardapio.ObterCardapioPorId(id);
                return result;
        }

        [HttpGet]
        public async Task<CardapioModel> ObterCardapioPrincipal()
        {
            var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
            var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
            var result = await ICardapio.ObterCardapioPrincipal();
            return result;
        }



        [HttpPost]
        public async Task<ResultApi> MenuListCardapio(int idCardapio, string titulo, string descricao, string[] produtos)
        {
            try
            {
                if (!String.IsNullOrEmpty(titulo) & produtos.Length > 0)
                {
                    int[] mylistProd = Array.ConvertAll(produtos, s => int.Parse(s));

                    var listCardapio = new MenuModel
                    {
                        codigoCardapio = idCardapio,
                        titulo = titulo,
                        descricao = descricao,
                        ListCodProduto = mylistProd.ToList()
                    };

                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                    var response = await ICardapio.PostListCardapio(listCardapio);
                    var result = new ResultApi { description = response.Message, erro = false };
                    return result;

                }
                else
                {
                    var resultado = new ResultApi { description = "Título do menu e produtos obrigatorio" };
                    return resultado;

                }

            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }

        }

        [HttpGet]
        public async Task<CardapioModel> BuscarMenuListaCardapio(int idCardapio)
        {
            try
            {
                
                var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                var responseListMenu = await ICardapio.GetListMenuCardapioPorId(idCardapio);
                
                var ListaProduto = ProdutoModel.ObterListaIdProduto(responseListMenu);
                var IProdutoServico = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var ListProdutoModel = await IProdutoServico.GetListProdutoPorListProduto(ListaProduto);
                //Refetora padrão repository
                var ListDeMenuComProdutos = MenuModel.ObterListaDeMenuComListaDeProduto(responseListMenu, ListProdutoModel);
                
                return new CardapioModel
                {
                    ListMenu = ListDeMenuComProdutos,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // POST: CardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CardapioModel collection)
        {
            try
            {
                if (AutenticanteVerifiy())
                {
                    var IcardapioAPI = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                    collection.idUser = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var result = await IcardapioAPI.Post(collection);
                    SetFlash(Enum.FlashMessageType.Success, result.Message);
                    return RedirectToAction("Create", "Cardapio"); ;
                }
                return View();
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }
        }


        [HttpDelete]
        public async Task<ResultApi> DeleteMenuListaCardapio(string codMenuSeq)
        {
            try
            {
                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                    var response = await ICardapio.DeleleteListaMenu(codMenuSeq);
                    var result = new ResultApi { description = response.Message, erro = false };
                    return result;

            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }

        }

        [HttpPost]
        public async Task<ResultApi> AlterarMenuListaCardapio(int idCardapio, string titulo, string descricao, string[] produtos,string codMenuSeq)
        {
            try
            {
                if (!String.IsNullOrEmpty(titulo) & produtos.Length > 0)
                {
                    int[] mylistProd = Array.ConvertAll(produtos, s => int.Parse(s));

                    var listCardapio = new MenuModel
                    {
                        codigoCardapio = idCardapio,
                        codMenuSeq = codMenuSeq,
                        titulo = titulo,
                        descricao = descricao,
                        ListCodProduto = mylistProd.ToList()
                    };

                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                    var response = await ICardapio.UpdateListaMenu(listCardapio);
                    var result = new ResultApi { description = response.Message, erro = false };
                    return result;

                }
                else
                {
                    var resultado = new ResultApi { description = "Título do menu e produtos obrigatorio" };
                    return resultado;

                }

            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }
        }


        [HttpDelete]
        public async Task<ResultApi> DeleteCardapio(int id)
        {
            try
            {
                var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                var response = await ICardapio.DeleteCardapio(id, email);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;

            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }

        }

        [HttpPut]
        public async Task<ResultApi> AtualizaCardapio(int id, string titulo)
        {
            try
            {
                var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                var response = await ICardapio.AtualizaCardapio(id,titulo);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;

            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }

        }

        [HttpPost]
        public async Task<ResultApi> DefinirCardapioPrincipal(int codCardapio)
        {
            try
            {
                var ICardapio = RestService.For<ICardapioServico>(Servico.Servico.UrlBaseFoodService());
                var response = await ICardapio.DefinirCardapioPrincipal(codCardapio);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = "Erro server : " + ex.Message, erro = true };
                return result;
            }

        }

    }
}
