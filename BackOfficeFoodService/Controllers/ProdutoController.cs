using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOfficeFoodService.Models;
using BackOfficeFoodService.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BackOfficeFoodService.Controllers
{
    public class ProdutoController : ControllerBase
    {
        // GET: ProdutoController
        public async Task<ActionResult> Index()
        {
            try
            {
                if (AutenticanteVerifiy())
                {
                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                    var result = await IProduto.GetListProdutoPorCliente(email);
                    return View(result);
                }
                else { return RedirectToAction("index", "login"); }
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }
        }

        // GET: ProdutoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (AutenticanteVerifiy())
            {
                var cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var resultProduto = await IProduto.GetProduto(id);
                var resultProdutoEmMenu = await IProduto.VerificaProdutoMenu(id, cliente);
                SetFlash(Enum.FlashMessageType.Warning, resultProdutoEmMenu.Message);
                return View(resultProduto);
            }
            else { return RedirectToAction("index", "login"); }
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return AutenticanteRetirect();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AutenticanteVerifiy())
                    {
                        collection.valor = Convert.ToDecimal(collection.valorDecimal);
                        collection.cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                        var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                        var result = await IProduto.Post(collection);
                        SetFlash(Enum.FlashMessageType.Success, result.Message);
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }
        }

        // GET: ProdutoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (AutenticanteVerifiy())
            {
                var cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var resultProduto = await IProduto.GetProduto(id);
                var resultProdutoEmMenu = await IProduto.VerificaProdutoMenu(id, cliente);
                SetFlash(Enum.FlashMessageType.Warning, resultProdutoEmMenu.Message);
                return View(resultProduto);
            }
            else { return RedirectToAction("index", "login"); }
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AutenticanteVerifiy())
                    {
                        ProdutoModel novoProduto = new ProdutoModel();
                        novoProduto.nome = collection["nome"];
                        novoProduto.descricao = collection["descricao"];
                        novoProduto.valor = Convert.ToDecimal(collection["valorDecimal"]);
                        novoProduto.cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                        var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                        var result = await IProduto.Edicao(id,novoProduto);
                        SetFlash(Enum.FlashMessageType.Success, result.Message);
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return View();
            }
        }

        // GET: ProdutoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (AutenticanteVerifiy())
            {
                var cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var resultProduto = await IProduto.GetProduto(id);
                var resultProdutoEmMenu = await IProduto.VerificaProdutoMenu(id, cliente);
                SetFlash(Enum.FlashMessageType.Warning, resultProdutoEmMenu.Message);
                return View(resultProduto);
            }
            else { return RedirectToAction("index", "login"); }
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            if (AutenticanteVerifiy())
            {
                var cliente = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                var IProduto = RestService.For<IProdutoServico>(Servico.Servico.UrlBaseFoodService());
                var result = await IProduto.DeleteProdutoPorCliente(id, cliente);
                SetFlash(Enum.FlashMessageType.Success, result.Message);
                return RedirectToAction("index", "Produto");
            }
            else { return RedirectToAction("index", "login"); }
        }
    }
  
}
