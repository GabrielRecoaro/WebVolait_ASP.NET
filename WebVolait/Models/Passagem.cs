using System;
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

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomePassagem { get; set; }

        [Display(Name = "Descrição da Passagem")]
        [MaxLength(50)]
        public string DescPassagem { get; set; }

        [Display(Name = "Partida Passagem")]
        public string PartidaPassagem { get; set; }

        [Display(Name = "Destino")]
        public int DestinoPassagem { get; set; }

        [Display(Name = "Valor da Passagem: BRL")]
        public int ValorPassagem { get; set; }

    }
}