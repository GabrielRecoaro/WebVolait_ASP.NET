using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVolait.ViewModels
{
    public class CadastroCompraViewModel
    {

        public int NotaFiscal { get; set; }

        public DateTime DataCompra { get; set; }

        public decimal ValorTotal { get; set; }

        public string CPFCliente { get; set; }

        public int Cupom { get; set; }

        public int CodTipoPagto { get; set; }

    }
}