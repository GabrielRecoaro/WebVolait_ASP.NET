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


        [HttpPost]
        public ActionResult InsertCompra(Compra compra)
        {
            //if (!ModelState.IsValid)

                //return View(viewmodel);

            // Compra novocompra = new Compra
            // {
            //     DataCompra = viewmodel.DataCompra,
            //     ValorTotal = viewmodel.ValorTotal,
            //     CPFCliente = viewmodel.CPFCliente,
            //     Cupom = viewmodel.Cupom,
            //     CodTipoPagto = viewmodel.CodTipoPagto,
            // };

            compra.InsertCompra(compra);
            TempData["MensagemLogin"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("ListarCompra", "Compra");
        }

        public ActionResult TotalCompra()
        {
            return View();
        }

        public ActionResult SelectCompra(string vNotaFiscal)
        {
            var ExibirCompra = new Acoes();
            var TodosCompra = ExibirCompra.SelectCompra();
            return View(TodosCompra);
        }


        //public ActionResult ListarCompra()
        //{
        //    var ExibirCompra = new Acoes();
        //    var TodosCompra = ExibirCompra.ListarCompra();
        //    return View(TodosCompra);

        //}

        //public ActionResult AlterarValorCompra(int id)
        //{
        //    var compraselecionado = ac.ListarCodCompra(id);
        //    return View(compraselecionado);
        //}

        //[HttpPost]
        //public ActionResult AlterarValorCompra(Compra compra)
        //{
        //    try
        //    {
        //        compra.UpdateCompra(compra);
        //        return RedirectToAction("ListarCompra", "Compra");
        //    }
        //    catch
        //    {
        //        return View(compra);
        //    }
        //}

    }
}