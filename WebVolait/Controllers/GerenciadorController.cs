using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVolait.Repositorio;

namespace WebVolait.Controllers
{
    public class GerenciadorController : Controller
    {
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }


    }
}