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
        public ActionResult InsertCompra()
        {
            return View();
        }

        public ActionResult Compra()
        {
            var compra = new Compra();
            return View(compra);
        }

        Acoes ac = new Acoes();


        [HttpPost]
        public ActionResult InsertCompra(CadastroCompraViewModel viewmodel)
        {
            //if (!ModelState.IsValid)

                //return View(viewmodel);

            Compra novocompra = new Compra
            {
                DataCompra = viewmodel.DataCompra,
                ValorTotal = viewmodel.ValorTotal,
                CPFCliente = viewmodel.CPFCliente,
                Cupom = viewmodel.Cupom,
                CodTipoPagto = viewmodel.CodTipoPagto,
            };

            novocompra.InsertCompra(novocompra);
            TempData["MensagemLogin"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("ListarCompra", "Compra");
        }

        public ActionResult ListarCompra()
        {
            var ExibirCompra = new Acoes();
            var TodosCompra = ExibirCompra.ListarCompra();
            return View(TodosCompra);

        }

    }
}