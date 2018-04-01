using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesceUmaGeralada.Models
{
    public class NotaFiscal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotaFiscalID { get; set; }
        public string Tipo { get; set; }
        public int Observacao { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
