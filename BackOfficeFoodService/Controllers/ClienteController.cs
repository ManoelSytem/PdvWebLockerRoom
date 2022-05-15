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
    public class ClienteController : ControllerBase
    {
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            try
            {
                if (AutenticanteVerifiy())
                {
                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICliente = RestService.For<IClienteServico>(Servico.Servico.UrlBaseFoodService());
                    var result = await ICliente.ObterListaDeCliente();
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

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return AutenticanteRetirect();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AutenticanteVerifiy())
                    {
                        var ICliente = RestService.For<IClienteServico>(Servico.Servico.UrlBaseFoodService());
                        collection.email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                        var result = await ICliente.Post(collection);
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

        // GET: ClienteController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int IdUser)
        {
            try
            {
                if (AutenticanteVerifiy())
                {
                    var email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                    var ICliente = RestService.For<IClienteServico>(Servico.Servico.UrlBaseFoodService());
                    var result = await ICliente.ObterClientePorIdUser(IdUser);
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

        // POST: ClienteController/Edit/5
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
                        ClienteModel clienteModel = new ClienteModel();
                        clienteModel.IdUser = Convert.ToInt32(collection["IdUser"]);
                        clienteModel.nome = collection["nome"];
                        clienteModel.endereco = collection["endereco"];
                        clienteModel.contato = collection["contato"];
                        clienteModel.email = HttpContext.Session.GetObject<Usuario>("Usuario").Email;
                       
                        var ICliente = RestService.For<IClienteServico>(Servico.Servico.UrlBaseFoodService());
                        var result = await ICliente.AtualizarCliente(clienteModel);
                       
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
