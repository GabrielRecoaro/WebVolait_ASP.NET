using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVolait.ViewModels
{
    public class CadastroCupomViewModel
    {

        public int CupomId { get; set; }

        public string Cupomcode { get; set; }

        public decimal Valordesconto { get; set; }

        public DateTime Cupomvalidade { get; set; }

    }
}