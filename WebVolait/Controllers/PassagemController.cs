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
     
        public ActionResult Passagem()
        {
            var passagem = new Passagem();
            return View(passagem);
        }

        public ActionResult ListarPassagem()
        {
            var ExibirPass = new Acoes();
            var TodosPass = ExibirPass.ListarPassagem();
            return View(TodosPass);

        }

        Acoes ac = new Acoes();

        [HttpPost]

        public ActionResult InsertPassagem(CadastroPassagemViewModel viewmodel)
        {
            if (!ModelState.IsValid)

                return View(viewmodel);

            Passagem novopassagem = new Passagem
            {
                NomePassagem = viewmodel.NomePassagem,
                DescPassagem = viewmodel.DescPassagem,
                ImgPassagem = viewmodel.ImgPassagem,
                ValorPassagem = viewmodel.ValorPassagem,
                Classe = viewmodel.Classe,
                CiaAerea= viewmodel.CiaAerea,
                IdAeroPartida = viewmodel.IdAeroPartida,
                IdAeroDestino = viewmodel.IdAeroDestino,
                DtHrPartida = viewmodel.DtHrPartida,
                DtHrChegada = viewmodel.DtHrChegada,
                DuracaoVoo= viewmodel.DuracaoVoo,
  
            };

            novopassagem.InsertPasssagem(novopassagem);

            TempData["MensagemLogin"] = "Passagem inserida com sucesso!";

            return RedirectToAction("ListarPassagem", "Passagem");

        }
    }
}


   