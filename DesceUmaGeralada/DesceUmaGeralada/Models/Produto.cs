using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesceUmaGeralada.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public int NotaFiscalID { get; set; }
        public int ClienteID { get; set; }
        

        public NotaFiscal NotaFiscal { get; set; }
        public Cliente Cliente { get; set; }
    }
}
