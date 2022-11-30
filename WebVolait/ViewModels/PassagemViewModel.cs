using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.ViewModels
{
    public class PassagemViewModel
    {

        public int IdPassagem { get; set; }

        [Display(Name = "Passagem aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string NomePassagem { get; set; }

        [Display(Name = "Descrição da passagem aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string DescPassagem { get; set; }

        public string ImgPassagem { get; set; }

        [Display(Name = "Valor da passagem")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public decimal ValorPassagem { get; set; }

        [Display(Name = "Data e horário da partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DtHrPartida { get; set; }

        [Display(Name = "Data e horário da chegada")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public DateTime DtHrChegada { get; set; }

        [Display(Name = "Tempo de duração do voo")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public TimeSpan DuracaoVoo { get; set; }

        [Display(Name = "Companhia aérea")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CiaAerea { get; set; }

        [Display(Name = "Classe da passagem")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Classe { get; set; }

        [Display(Name = "Sigla do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string IdAeroPartida { get; set; }

        [Display(Name = "Sigla do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string IdAeroDestino { get; set; }

        [Display(Name = "Sigla do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string NomeAeroPartida { get; set; }

        [Display(Name = "Sigla do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string NomeAeroDestino { get; set; }

        [Display(Name = "Cidade do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CidadeAeroPartida { get; set; }

        [Display(Name = "Cidade do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CidadeAeroDestino { get; set; }

        [Display(Name = "Estado do aeroporto de partida")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string UFAeroPartida { get; set; }

        [Display(Name = "Estado do aeroporto de destino")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string UFAeroDestino { get; set; }

    }
}