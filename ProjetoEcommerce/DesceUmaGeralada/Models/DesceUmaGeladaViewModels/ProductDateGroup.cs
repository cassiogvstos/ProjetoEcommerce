using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DesceUmaGeralada.Models.DesceUmaGeladaViewModels
{
    public class ProductDateGroup
    {
      [DataType(DataType.Date)]
      public int? ProdutoCount { get; set; }

      public int ClienteCount { get; set; }
        
    }
}
