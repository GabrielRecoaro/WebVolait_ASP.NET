using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebVolait.Models;
using WebVolait.Repositorio;
using WebVolait.ViewModels;

namespace WebVolait.Controllers
{
    public class PassagemController : Controller
    {
        [HttpGet]

        public ActionResult InsertPassagem()
        {
            return View();
        }

        public ActionResult ListarPassagem()
        {
            var ExibirPass = new Acoes();
            var TodosPass = ExibirPass.ListarPassagem();
            return View(TodosPass);

        }

        [HttpPost]

        public ActionResult InsertPassagem(CadastroPassagemViewModel viewmodel)
        {
            if (!ModelState.IsValid)

                return View(viewmodel);

            Passagem novopassagem = new Passagem
            {
                NomePassagem = viewmodel.NomePassagem,
                DescPassagem = viewmodel.DescPassagem,
                Origem = viewmodel.Origem,
                Destino = viewmodel.Destino,
                IdAeroDestino = viewmodel.IdAeroDestino,
                IdAeroOrigem = viewmodel.IdAeroOrigem,
                //DtHrPartida = DateTime.Parse(viewmodel.DataHrPartida),
                //DtHrChegada = DateTime.Parse(viewmodel.DataHrChegada),
                ImgPassagem = viewmodel.ImgPassagem,
                ValorPassagem = viewmodel.ValorPassagem,
                Classe = viewmodel.Classe

            };

            novopassagem.InsertPasssagem(novopassagem);

            TempData["MensagemLogin"] = "Passagem inserida com sucesso!";

            return RedirectToAction("ListarPassagem", "AutenticacaoPassagem");

        }
    }
}


   