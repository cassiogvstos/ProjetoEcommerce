using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DesceUmaGeralada.Models
{
    public class NotaFiscal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotaFiscalID { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public string Nome { get; set; }
        public string ProdutoDescricao { get; set; }
        public DateTime data { get; set; }

        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }


    }
}
