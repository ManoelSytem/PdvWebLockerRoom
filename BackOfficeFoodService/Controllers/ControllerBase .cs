using BackOfficeFoodService.Enum;
using BackOfficeFoodService.Models;
using BackOfficeFoodService.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Controllers
{
    public class ControllerBase : Controller
    {
        public void SetFlash(FlashMessageType type, string text)
        {
            TempData["FlashMessage.Type"] = type;
            TempData["FlashMessage.Text"] = text;
        }

        public ActionResult AutenticanteRetirect()
        {
            var Session = HttpContext.Session.GetObject<Usuario>("Usuario");
            if (Session != null)
            {
                if (HttpContext.Session.GetObject<Usuario>("Usuario").IsAuthenticated)
                {
                    return View();
                }
                else { return RedirectToAction("index", "login"); }
            }
            else
            {
                return RedirectToAction("index", "login");
            }
        }

        public bool AutenticanteVerifiy()
        {
            var Session = HttpContext.Session.GetObject<Usuario>("Usuario");
            if (Session != null)
            {
                if (HttpContext.Session.GetObject<Usuario>("Usuario").IsAuthenticated)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }

    }
}
