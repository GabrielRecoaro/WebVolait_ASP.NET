﻿using System;
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
        [Authorize]
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
        [Authorize]
        public ActionResult InsertCupom(CadastroCupomViewModel viewmodel)
        {
            if (!ModelState.IsValid)

             return View(viewmodel);

            Cupom novocupom = new Cupom
            {
                Cupomcode = viewmodel.Cupomcode,
                Valordesconto = viewmodel.Valordesconto,
                Cupomvalidade = viewmodel.Cupomvalidade,
            };

            novocupom.InsertCupom(novocupom);

            TempData["MensagemLogin"] = "Cupom cadastrado com sucesso!";

            return RedirectToAction("ListarCupom", "Cupom");

        }
        [Authorize]
        public ActionResult ListarCupom()
        {
            var ExibirCupom = new Acoes();
            var TodosCumpom = ExibirCupom.ListarCupom();
            return View(TodosCumpom);

        }
        [Authorize]
        public ActionResult AlterarCupom(int id)
        {
            var cupomselecionado = ac.ListarCodCupom(id);
            return View(cupomselecionado);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AlterarCupom(Cupom cupom)
        {
            try
            {
                cupom.UpdateCupom(cupom);
                return RedirectToAction("ListarCupom", "Cupom");
            }
            catch
            {
                TempData["MensagemLogin"] = "Não foi possível realizar a alteração";
                return View(cupom);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeletarCupom(int id)
        {
            var cupomselecionado = ac.ListarCodCupom(id);
            return View(cupomselecionado);
            
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeletarCupom(Cupom cupom)
        {
            try
            {
                cupom.DeleteCupom(cupom);
                return RedirectToAction("ListarCupom", "Cupom");

            }
            catch
            {
                TempData["MensagemLogin"] = "Não foi possível realizar a remoção";                
                return View(cupom);
            }
        }
    }
}