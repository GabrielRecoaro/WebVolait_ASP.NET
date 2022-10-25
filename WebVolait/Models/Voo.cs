using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Voo
    {

        public int IdVoo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Data e Hora da Partida", AutoGenerateFilter = false)]
        public string DataHrPartida { get; set; }

        [Display(Name = "Data e Hora da Chegada")]
        [MaxLength(50)]
        public string DataHrChegada { get; set; }

        [Display(Name = "Escala")]
        public string Escala { get; set; }

        [Display(Name = "Descrição da Escala")]
        public string DescEscala { get; set; }

    }
}