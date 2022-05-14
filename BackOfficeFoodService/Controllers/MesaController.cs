using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOfficeFoodService.Models;
using BackOfficeFoodService.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Refit;

namespace BackOfficeFoodService.Controllers
{
    public class MesaController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create(MesaModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AutenticanteVerifiy())
                    {
                        var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
                        var result = await IMesaService.Post(collection);
                        SetFlash(Enum.FlashMessageType.Success, result.Message);
                        return RedirectToAction("index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                SetFlash(Enum.FlashMessageType.Error, ex.Message);
                return RedirectToAction("index");
            }
        }

        public async Task<IActionResult> GerenciaMesa()
        {
            var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
            var result = await IMesaService.ObterListaMesa();
            return View(result);
        }

        public async Task<ResultApi> AbrirMesa(int codMesa, int numeroMesa)
        {
            try
            {
                var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
                var response = await IMesaService.AbrirMesa(codMesa,numeroMesa);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = ex.Message, erro = true };
                return result;
            }


        }

        public async Task<IActionResult> MesaConsumo(int codigo, int numeroMesa, string seqAbreMesa)
        {
            var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
            var result =  await IMesaService.ObterConsumoDaMesa(seqAbreMesa,false);
            TempData["codigo"] = codigo;
            TempData["numeroMesa"] = numeroMesa;
            TempData["seqAbreMesa"] = seqAbreMesa;
            return View(result);
        }
      
        [HttpPost]
        public async Task<ResultApi> FechamentoMesa(int codMesa, string seqAbreMesa, decimal totalFechamento)
        {
            try
            {
                var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
                var response = await IMesaService.FechamentoMesa(codMesa, seqAbreMesa, totalFechamento);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = ex.Message, erro = true };
                return result;
            }

        }

        public async Task<IActionResult> FechamentoMesa(int codigo, int numeroMesa, string seqAbreMesa)
        {
            var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
            var result = await IMesaService.ObterConsumoDaMesa(seqAbreMesa,false);
            TempData["codigo"] = codigo;
            TempData["numeroMesa"] = numeroMesa;
            TempData["seqAbreMesa"] = seqAbreMesa;
            return View(result);
        }


        

        public async Task<ResultApi> AdicionarConsumoMesa(string codMesa, string codProduto)
        {
            try
            {
                var itemConsumo = new ConsumoModel
                {
                    codMesa = codMesa,
                    codProduto = codProduto
                };

                var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
                var response = await IMesaService.AdicionaConsumoMesa(itemConsumo);
                var result = new ResultApi { description = response.Message, erro = false };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultApi { description = ex.Message, erro = false };
                return result;
            }
        }

        public async Task<ResultApi> DeleteProdutoConsumoMesa(string codigoItemConsumo, int codMesa)
        {
            try
            {
                var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
                var response = await IMesaService.DeleteProdutoConsumoMesa(codigoItemConsumo, codMesa);

                var result = new ResultApi { description = response.Message, erro = false };
                return result;
            }
            catch (Exception ex )
            {
                var result = new ResultApi { description = ex.Message, erro = false };
                return result;
            }
           
        }


        public async Task<List<ConsumoModel>> ObterConsumoMesa(string seqAbreMesa)
        {
            var IMesaService = RestService.For<IMesaService>(Servico.Servico.UrlBaseFoodService());
            var result = await IMesaService.ObterConsumoDaMesa(seqAbreMesa,false);
            return result;
        }
    }
}
