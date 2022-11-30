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
            Acoes acoes = new Acoes();
            var listaPassagensViewModel = acoes.ListarTodasPassagensViewModel();
            return View(listaPassagensViewModel);
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }


    }
}