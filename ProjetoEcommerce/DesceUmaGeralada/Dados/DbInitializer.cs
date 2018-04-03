using DesceUmaGeralada.Models;
using System;
using System.Linq;

namespace DesceUmaGeralada.Dados
{
    public static class DbInitializer
    {
        public static void Initialize(BeerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Clientes.
            if (context.Clientes.Any())
            {
                return;   // DB has been seeded
            }

            var Clientes = new Cliente[]
            {
            new Cliente{Nome="Carson",SobreNome="Alexander",ProdutoDate=DateTime.Parse("2018-09-01")},
            new Cliente{Nome="Meredith",SobreNome="Alonso",ProdutoDate=DateTime.Parse("2016-09-01")},
            new Cliente{Nome="Arturo",SobreNome="Anand",ProdutoDate=DateTime.Parse("2015-09-01")},
            new Cliente{Nome="Gytis",SobreNome="Barzdukas",ProdutoDate=DateTime.Parse("2017-09-01")},
            new Cliente{Nome="Yan",SobreNome="Li",ProdutoDate=DateTime.Parse("2013-09-01")},
            new Cliente{Nome="Peggy",SobreNome="Justice",ProdutoDate=DateTime.Parse("2010-09-01")},
            new Cliente{Nome="Laura",SobreNome="Norman",ProdutoDate=DateTime.Parse("2014-09-01")},
            new Cliente{Nome="Nino",SobreNome="Olivetto",ProdutoDate=DateTime.Parse("2015-09-01")}
            };
            foreach (Cliente s in Clientes)
            {
                context.Clientes.Add(s);
            }
            context.SaveChanges();

            var notas = new NotaFiscal[]
            {
            new NotaFiscal{NotaFiscalID=1050,Tipo="VendaAVista",Observacao=3},
            new NotaFiscal{NotaFiscalID=4022,Tipo="VendaAPrazo",Observacao=3},
            new NotaFiscal{NotaFiscalID=4041,Tipo="VendaAVistaCartao",Observacao=3},
            new NotaFiscal{NotaFiscalID=1045,Tipo="VendaAPrazoCartao",Observacao=4},
            new NotaFiscal{NotaFiscalID=3141,Tipo="Devolucao",Observacao=4},
            new NotaFiscal{NotaFiscalID=2021,Tipo="CompraAVista",Observacao=3},
            new NotaFiscal{NotaFiscalID=2042,Tipo="CompraAPrazo",Observacao=4}
            };
            foreach (NotaFiscal c in notas)
            {
                context.NotasFiscais.Add(c);
            }
            context.SaveChanges();

            var produtos = new Produto[]
            {
            new Produto{ClienteID=1,NotaFiscalID=1050},
            new Produto{ClienteID=1,NotaFiscalID=4022},
            new Produto{ClienteID=1,NotaFiscalID=4041},
            new Produto{ClienteID=2,NotaFiscalID=1045},
            new Produto{ClienteID=2,NotaFiscalID=3141},
            new Produto{ClienteID=2,NotaFiscalID=2021},
            new Produto{ClienteID=3,NotaFiscalID=1050},
            new Produto{ClienteID=4,NotaFiscalID=1050},
            new Produto{ClienteID=4,NotaFiscalID=4022},
            new Produto{ClienteID=5,NotaFiscalID=4041},
            new Produto{ClienteID=6,NotaFiscalID=1045},
            new Produto{ClienteID=7,NotaFiscalID=3141},
            };
            foreach (Produto e in produtos)
            {
                context.Produtos.Add(e);
            }
            context.SaveChanges();
        }
    }
}