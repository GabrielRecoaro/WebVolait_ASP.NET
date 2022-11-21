using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVolait.Models;
using WebVolait.Repositorio;
using WebVolait.ViewModels;

namespace WebVolait.Controllers
{
    public class CupomController : Controller
    {
        [HttpGet]

        public ActionResult InsertCupom()
        {
            return View();
        }

        public ActionResult Cupom()
        {
            var cupom = new Cupom();
            return View(cupom);
        }


        Acoes ac = new Acoes();


        [HttpPost]

        public ActionResult InsertCupom(CadastroCupomViewModel viewmodel)
        {
            if (!ModelState.IsValid)

                return View(viewmodel);

            Cupom novocupom = new Cupom
            {
                IdCupom = viewmodel.IdCupom,
                DescCupom = viewmodel.DescCupom,
                ValorCupom = viewmodel.ValorCupom,
            };

            novocupom.InsertCupom(novocupom);

            TempData["MensagemLogin"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("ListarCupom", "AutenticacaoCupom");

        }
    }
}