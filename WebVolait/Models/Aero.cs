using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVolait.Models
{
    public class Aero
    {
        public string IdAero { get; set; }
        public string NomeAero { get; set; }
        public string CidadeAero { get; set; }
        public string UfAero { get; set; }

        public Aero() { }

        public Aero(string IdAero_, string NomeAero_, string CidadeAero_, string UfAero_)
        {
            this.IdAero = IdAero_;
            this.NomeAero = NomeAero_;
            this.CidadeAero = CidadeAero_;
            this.UfAero = UfAero_;
        }
    }
}