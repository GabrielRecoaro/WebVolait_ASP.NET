using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebVolait.Models;

namespace WebVolait.ViewModels
{
    public class CompraViewModel
    {
        public int IdPassagem { get; set; }
        
        public string NomePassagem { get; set; }
        
        public string DescPassagem { get; set; }

        public string ImgPassagem { get; set; }

        public decimal ValorPassagem { get; set; }

        public DateTime DtHrPartida { get; set; }

        public DateTime DtHrChegada { get; set; }
        
        public int DuracaoVoo { get; set; }
        
        public string CiaAerea { get; set; }
        
        public string Classe { get; set; }

        public int NotaFiscal { get; set; }

        public string IdAeroPartida { get; set; }

        public string IdAeroDestino { get; set; }

        public string CidadeAeroPartida { get; set; }
        
        public string CidadeAeroDestino { get; set; }

        public string UFAeroPartida { get; set; }
        
        public string UFAeroDestino { get; set; }

        public int QtdPassagem { get; set; }

        public decimal ValorTotal { get; set; }

        public string TipoPgto { get; set; }


        // public DateTime DataCompra { get; set; }

        // public long CPFCliente { get; set; }

        // public string Cupom { get; set; }

        // public string CodTipoPagto { get; set; }

        // public int IdTipoPgto { get; set; }

    }
}