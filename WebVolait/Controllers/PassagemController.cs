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
        [Authorize]
        public ActionResult InsertPassagem()
        {
            return View();
        }
     
        public ActionResult Passagem()
        {
            var passagem = new Passagem();
            return View(passagem);
        }

        Acoes ac = new Acoes();

        [HttpPost]
        [Authorize]
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
                DuracaoVoo = viewmodel.DuracaoVoo,

            };

            novopassagem.InsertPasssagem(novopassagem);

            TempData["MensagemLogin"] = "Passagem inserida com sucesso!";

            return RedirectToAction("ListarPassagem", "Passagem");

        }

        [Authorize]
        public ActionResult ListarPassagem()
        {
            var ExibirPassagem = new Acoes();
            var TodosPassagem = ExibirPassagem.ListarPassagem();
            return View(TodosPassagem);

        }

        public ActionResult ListarPassagemCliente()
        {
            var ExibirPassagem = new Acoes();
            var TodosPassagem = ExibirPassagem.ListarPassagem();
            return View(TodosPassagem);

        }

        public ActionResult DetalhesPassagem(int id)
        {
            var passagemselecionado = ac.ListarPassagensViewModelById(id);
            return View(passagemselecionado);
        }


        [Authorize]
        public ActionResult AlterarPassagem(int id)
        {
            var passagemselecionado = ac.ListarCodPassagem(id);
            return View(passagemselecionado);


        }

        [HttpPost]
        [Authorize]
        public ActionResult AlterarPassagem(Passagem passagem)
        {
            try
            {
                passagem.UpdatePassagem(passagem);
                return RedirectToAction("ListarPassagem", "Passagem");
            }
            catch
            {
                TempData["MensagemLogin"] = "Não foi possível realizar a alteração";           
                return View(passagem);
            }

        }

        [HttpGet]
        [Authorize]
        public ActionResult DeletarPassagem(int id)
        {
            var passagemselecionado = ac.ListarCodPassagem(id);
            return View(passagemselecionado);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeletarPassagem(Passagem passagem)
        {
            try
            {
                passagem.DeletePassagem(passagem);
                return RedirectToAction("ListarPassagem", "Passagem");
            }
            catch
            {
                TempData["MensagemLogin"] = "Não foi possível realizar a remoção";               
                return RedirectToAction("ListarPassagem", "Passagem");
            }
        }
    }
}


   