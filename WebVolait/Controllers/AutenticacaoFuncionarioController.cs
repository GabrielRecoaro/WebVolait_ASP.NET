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
    public class AutenticacaoFuncionarioController : Controller
    {
        [HttpGet]

        public ActionResult InsertFuncionario()
        {
            return View();
        }

        public ActionResult Funcionario()
        {
            var funcionario = new Funcionario();
            return View(funcionario);
        }

        Acoes ac = new Acoes();

        [HttpPost]

        public ActionResult InsertFuncionario(CadastroFuncionarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)

                return View(viewmodel);

            Funcionario novofuncionario = new Funcionario
            {
                CPFFuncionario = viewmodel.CPFFuncionario,
                NomeFuncionario = viewmodel.NomeFuncionario,
                NomeSocialFuncionario = viewmodel.NomeSocialFuncionario,
                EmailFuncionario = viewmodel.EmailFuncionario,
                TelefoneFuncionario = viewmodel.TelefoneFuncionario,
                SenhaFuncionario = viewmodel.SenhaFuncionario,
                FuncaoFuncionario = viewmodel.FuncaoFuncionario
            };

            novofuncionario.InsertFuncionario(novofuncionario);

            return RedirectToAction("ListarFuncionario", "AutenticacaoFuncionario");

        }

        public ActionResult ListarFuncionario()
        {
            var ExibirFunc = new Acoes();
            var TodosFunc = ExibirFunc.ListarFuncionario();
            return View(TodosFunc);

        }
    }
}