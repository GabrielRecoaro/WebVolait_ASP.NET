﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Passagem
    {

        public int IdPassagem { get; set; }

        public string NomePassagem { get; set; }

        public string DescPassagem { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string CidadeAeroOrigem { get; set; }

        public string CidadeAeroDestino { get; set; }

        public DateTime DtHrPartida { get; set; }

        public DateTime DtHrChegada { get; set; }

        public string ImgPassagem { get; set; }

        public decimal ValorPassagem { get; set; }

        public string Classe { get; set; }

    }
}