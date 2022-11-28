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
        
        [Display(Name ="Passagem aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string NomePassagem { get; set; }
        
        [Display(Name ="Descrição da passagem aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string DescPassagem { get; set; }
        
        public string ImgPassagem { get; set; }

        [Display(Name ="Valor da passagem")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public decimal ValorPassagem { get; set; }

        [Display(Name ="Data e horário da partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DtHrPartida { get; set; }
        public DateTime DtHrPartida { get; set; }

        [Display(Name ="Data e horário da chegada")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DtHrChegada { get; set; }
        
        [Display(Name ="Tempo de duração do voo")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int DuracaoVoo { get; set; }
        
        [Display(Name ="Companhia aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CiaAerea { get; set; }
        
        [Display(Name ="Classe da passagem")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Classe { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Nota fiscal da compra")]
        public int NotaFiscal { get; set; }

        [Display(Name ="Sigla do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string IdAeroPartida { get; set; }

        [Display(Name ="Sigla do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string IdAeroDestino { get; set; }

        [Display(Name ="Cidade do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CidadeAeroPartida { get; set; }
        
        [Display(Name ="Cidade do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CidadeAeroDestino { get; set; }

        [Display(Name ="Estado do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string UFAeroPartida { get; set; }
        
        [Display(Name ="Estado do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string UFAeroDestino { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Quantidade de passagens")]
        public int QtdPassagem { get; set; }

        [Display(Name = "Valor total da compra")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Tipo de pagamento")]
        public string TipoPgto { get; set; }


        // public DateTime DataCompra { get; set; }

        // public long CPFCliente { get; set; }

        // public string Cupom { get; set; }

        // public string CodTipoPagto { get; set; }

        // public int IdTipoPgto { get; set; }

    }
}
