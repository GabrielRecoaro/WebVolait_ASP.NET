using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.ViewModels
{
    public class CadastroPassagemViewModel
    {
        public string NomePassagem { get; set; }

        public string DescPassagem { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string IdAeroOrigem { get; set; }

        public string IdAeroDestino { get; set; }

        public DateTime DtHrPartida { get; set; }

        public DateTime DtHrChegada { get; set; }

        public string ImgPassagem { get; set; }

        public decimal ValorPassagem { get; set; }

        public string Classe { get; set; }

    }
}