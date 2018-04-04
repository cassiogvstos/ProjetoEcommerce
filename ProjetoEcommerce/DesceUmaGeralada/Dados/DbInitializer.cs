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
            new Cliente{Nome="Carson",SobreNome="Alexander",ProdutoDescricao="Eisenbahn"},
            new Cliente{Nome="Meredith",SobreNome="Alonso",ProdutoDescricao="Paulaner"},
            new Cliente{Nome="Arturo",SobreNome="Anand",ProdutoDescricao="Edgar"},
            new Cliente{Nome="Gytis",SobreNome="Barzdukas",ProdutoDescricao="Original"},
            new Cliente{Nome="Yan",SobreNome="Li",ProdutoDescricao="Bohemia"},
            new Cliente{Nome="Peggy",SobreNome="Justice",ProdutoDescricao="Burguesa"},
            new Cliente{Nome="Laura",SobreNome="Norman",ProdutoDescricao="Skol"},
            //new Cliente{Nome="Nino",SobreNome="Olivetto",ProdutoDate=DateTime.Parse("2015-09-01")}
            };
            foreach (Cliente s in Clientes)
            {
                context.Clientes.Add(s);
            }
            context.SaveChanges();

            var notas = new NotaFiscal[]
            {
            new NotaFiscal{NotaFiscalID=1050,Tipo="VendaAVista",Observacao="Isento de Imposto",ClienteID=1},
            new NotaFiscal{NotaFiscalID=4022,Tipo="VendaAPrazo",Observacao="Isento de Imposto",ClienteID=1},
            new NotaFiscal{NotaFiscalID=4041,Tipo="VendaAVistaCartao",Observacao="Isento de Imposto",ClienteID=2},
            new NotaFiscal{NotaFiscalID=1045,Tipo="VendaAPrazoCartao",Observacao="Isento de Imposto",ClienteID=3},
            new NotaFiscal{NotaFiscalID=3141,Tipo="Devolucao",Observacao="Produto quebrado",ClienteID=4},
            new NotaFiscal{NotaFiscalID=2021,Tipo="CompraAVista",Observacao="Isento de Imposto",ClienteID=5},
            new NotaFiscal{NotaFiscalID=2042,Tipo="CompraAPrazo",Observacao="Isento de Imposto",ClienteID=4}
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