using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVolait.Repositorio;

namespace WebVolait.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult ListarPassagem()
        {
            var ExibirPass = new Acoes();
            var TodosPass = ExibirPass.ListarPassagem();
            return View(TodosPass);

        }
    }
}