using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesceUmaGeralada.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        //public int NotaFiscalID { get; set; }

        public ICollection<Produto> Produtos { get; set; }
        public DateTime ProdutoDate { get;  set; }
    }
}
