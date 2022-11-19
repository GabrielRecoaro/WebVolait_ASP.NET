using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebVolait.Models;
using WebVolait.Repositorio;
using WebVolait.ViewModels;
using WebVolait.Utils;
using Hash = WebVolait.Utils.Hash;

namespace WebVolait.Controllers
{
    public class AutenticacaoClienteController : Controller
    {
        [HttpGet]
        
        public ActionResult InsertCliente()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

     
        Acoes ac = new Acoes();


        [HttpPost]

        public ActionResult InsertCliente(CadastroClienteViewModel viewmodel)
        {
            if (!ModelState.IsValid)

                return View(viewmodel);

            Cliente novocliente = new Cliente
            {
                CPFCliente = viewmodel.CPFCliente,
                NomeCliente = viewmodel.NomeCliente,
                NomeSocialCliente = viewmodel.NomeSocialCliente,
                LoginCliente = viewmodel.LoginCliente,
                TelefoneCliente = viewmodel.TelefoneCliente,
                SenhaCliente = Hash.GerarHash(viewmodel.SenhaCliente)

            };

            novocliente.InsertCliente(novocliente);
           
            TempData["MensagemLogin"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("ListarCliente", "AutenticacaoCliente");

        }

        public ActionResult SelectLogin(string vLoginCliente)
        {
            bool LoginExists;
            string logincliente = new Cliente().SelectLogin(vLoginCliente);

            if (logincliente.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;

            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoginCliente(string ReturnUrl)
        {
            var viewmodel = new LoginClienteViewModel
            {
                urlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]


        public ActionResult LoginCliente(LoginClienteViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            Cliente cliente = new Cliente();
            cliente = cliente.SelectCliente(viewmodel.LoginCliente);

            if (cliente == null | cliente.LoginCliente != viewmodel.LoginCliente)
            {
                ModelState.AddModelError("LoginCliente", "Login incorreto");
                return View(viewmodel);
            }

            if (cliente.SenhaCliente != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("SenhaCliente", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, cliente.LoginCliente),
                new Claim("LoginCliente", cliente.LoginCliente)
            }, "AppAplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.urlRetorno) || Url.IsLocalUrl(viewmodel.urlRetorno))
                return Redirect(viewmodel.urlRetorno);
            else
                return RedirectToAction("Index", "Home");
            return View();

        }


        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppAplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ListarCliente()
        {
            var ExibirFunc = new Acoes();
            var TodosFunc = ExibirFunc.ListarCliente();
            return View(TodosFunc);

        }
    }
}