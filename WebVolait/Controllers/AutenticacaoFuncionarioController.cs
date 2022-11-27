using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebVolait.Models;
using WebVolait.Repositorio;
using WebVolait.ViewModels;
using Hash = WebVolait.Utils.Hash;

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
                LoginFuncionario = viewmodel.LoginFuncionario,
                TelefoneFuncionario = viewmodel.TelefoneFuncionario,
                SenhaFuncionario = Hash.GerarHash(viewmodel.SenhaFuncionario)

            };

            novofuncionario.InsertFuncionario(novofuncionario);

            return RedirectToAction("LoginFuncionario", "AutenticacaoFuncionario");

        }

        public ActionResult SelectLogin(string vLoginFuncionario)
        {
            bool LoginExists;
            string loginfuncionario = new Funcionario().SelectLogin(vLoginFuncionario);

            if (loginfuncionario.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;

            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoginFuncionario(string ReturnUrl)
        {
            var viewmodel = new LoginFuncionarioViewModel
            {
                urlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]

        public ActionResult LoginFuncionario(LoginFuncionarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            Funcionario funcionario = new Funcionario();
            funcionario = funcionario.SelectFuncionario(viewmodel.LoginFuncionario);

            if (funcionario == null | funcionario.LoginFuncionario != viewmodel.LoginFuncionario)
            {
                ModelState.AddModelError("LoginFuncionario", "Login incorreto");
                return View(viewmodel);
            }

            if (funcionario.SenhaFuncionario != Hash.GerarHash(viewmodel.SenhaFuncionario))
            {
                ModelState.AddModelError("SenhaFuncionario", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, funcionario.LoginFuncionario),
                new Claim("LoginFuncionario", funcionario.LoginFuncionario)
            }, "AppAplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.urlRetorno) || Url.IsLocalUrl(viewmodel.urlRetorno))
                return Redirect(viewmodel.urlRetorno);
            else
                return RedirectToAction("Index", "Gerenciador");
            

        }

        public ActionResult ListarFuncionario()
        {
            var ExibirFunc = new Acoes();
            var TodosFunc = ExibirFunc.ListarFuncionario();
            return View(TodosFunc);

        }

        public ActionResult AlterarFuncionario(string id)
        {
            var funcionarioselecionado = ac.ListarCodFuncionario(id);
            return View(funcionarioselecionado);
        }

        [HttpPost]
        public ActionResult AlterarFuncionario(Funcionario funcionario)
        {
            try
            {
                funcionario.UpdateFuncionario(funcionario);
                return RedirectToAction("ListarFuncionario", "AutenticacaoFuncionario");
            }
            catch
            {
                return View(funcionario);
            }
        }

        [HttpGet]
        public ActionResult DeletarFuncionario(string id)
        {           
            var funcionarioselecionado = ac.ListarCodFuncionario(id);
            return View(funcionarioselecionado);
        }

        [HttpPost]
        public ActionResult DeletarFuncionario(Funcionario funcionario)
        {
            try
            {             
                funcionario.DeleteFuncionario(funcionario);
                return RedirectToAction("ListarFuncionario", "AutenticacaoFuncionario");
            }
            catch
            {
                return RedirectToAction("ListarFuncionario", "AutenticacaoFuncionario");
            }
        }
    }
}