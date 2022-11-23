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
                CupomId = viewmodel.CupomId,
                Cupomcode = viewmodel.Cupomcode,
                Valordesconto = viewmodel.Valordesconto,
                Cupomvalidade = viewmodel.Cupomvalidade,
            };

            novocupom.InsertCupom(novocupom);

            TempData["MensagemLogin"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("ListarCupom", "AutenticacaoCupom");

        }
    }
}