using MySql.Data.MySqlClient;
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
    public class CompraController : Controller
    {
        [HttpGet]
        public ActionResult InsertCompra(int id)
        {
            Compra compra = new Compra();
            compra.Passagem = id;
            return View(compra);
        }

        public ActionResult Compra()
        {
            var compra = new Compra();
            return View(compra);
        }

        Acoes ac = new Acoes();

        public ActionResult SelectCompra(int id)
        {
            var vmCompra = ac.ListarCodCompra(id);
            return View(vmCompra);
        }

        [HttpPost]
        public ActionResult InsertCompra(Compra compra)
        {
            try
            {
                compra.InsertCompra(compra);
                TempData["MensagemLogin"] = "Compra realizada com sucesso! Obrigado por escolher Volait!";
                var ultimacompra = ac.ListarUltimaCodCompra();
                return RedirectToAction("SelectCompra/" + ultimacompra.NotaFiscal, "Compra");
            }

            catch
            {
                TempData["MensagemLogin"] = "Não foi possível realizar a compra. Por favor, verifique se o CPF digitado cadastrado está escrito corretamente e tente novamente.";
                return View(compra);
            }
        }

        public ActionResult TotalCompra()
        {
            return View();
        }

    }
}
