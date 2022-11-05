﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVolait.Models;
using WebVolait.ViewModels;

namespace WebVolait.Controllers
{
    public class AutenticacaoClienteController : Controller
    {
        [HttpGet]
        
        public ActionResult InsertCliente()
        {
            return View();
        }


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
                EmailCliente = viewmodel.EmailCliente,
                TelefoneCliente = viewmodel.TelefoneCliente,
                SenhaCliente = viewmodel.SenhaCliente

            };

            novocliente.InsertCliente(novocliente);
            
            return RedirectToAction("Index", "Home"); 

        }


    }
}