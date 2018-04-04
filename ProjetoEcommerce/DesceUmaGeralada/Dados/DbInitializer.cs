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
            new Cliente{Nome="Carson",SobreNome="Alexander",ProdutoDescricao="Eisenbahn",DataRegistro=DateTime.Parse("2018-04-04")},
            new Cliente{Nome="Meredith",SobreNome="Alonso",ProdutoDescricao="Paulaner",DataRegistro=DateTime.Parse("2016-03-29")},
            new Cliente{Nome="Arturo",SobreNome="Anand",ProdutoDescricao="Edgar",DataRegistro=DateTime.Parse("2001-11-21")},
            new Cliente{Nome="Gytis",SobreNome="Barzdukas",ProdutoDescricao="Original",DataRegistro=DateTime.Parse("2000-08-02")},
            new Cliente{Nome="Yan",SobreNome="Li",ProdutoDescricao="Bohemia",DataRegistro=DateTime.Parse("2017-10-22")},
            new Cliente{Nome="Peggy",SobreNome="Justice",ProdutoDescricao="Burguesa",DataRegistro=DateTime.Parse("2012-07-29")},
            new Cliente{Nome="Laura",SobreNome="Norman",ProdutoDescricao="Heineken",DataRegistro=DateTime.Parse("2012-05-29")}
            //new Cliente{Nome="Nino",SobreNome="Olivetto",ProdutoDate=DateTime.Parse("2015-09-01")}
            };
            foreach (Cliente s in Clientes)
            {
                context.Clientes.Add(s);
            }
            context.SaveChanges();

            var notas = new NotaFiscal[]
            {
            new NotaFiscal{NotaFiscalID=1050,Tipo="VendaAVista",Observacao="Isento de Imposto",Nome="Juca",ProdutoDescricao="Eisenbahn",data=DateTime.Now},
            new NotaFiscal{NotaFiscalID=4022,Tipo="VendaAPrazo",Observacao="Isento de Imposto",Nome="Luca Silva e Silva", ProdutoDescricao="Paulaner",data=DateTime.Now},
            new NotaFiscal{NotaFiscalID=4041,Tipo="VendaAVistaCartao",Observacao="Isento de Imposto",Nome="Ricardo", ProdutoDescricao="Edgar",data=DateTime.Now},
            new NotaFiscal{NotaFiscalID=1045,Tipo="VendaAPrazoCartao",Observacao="Isento de Imposto",Nome="Cassio", ProdutoDescricao="Original",data=DateTime.Now},
            new NotaFiscal{NotaFiscalID=3141,Tipo="Devolucao",Observacao="Produto quebrado",Nome="Fabinho", ProdutoDescricao="Bohemia",data=DateTime.Now},
            new NotaFiscal{NotaFiscalID=2021,Tipo="CompraAVista",Observacao="Isento de Imposto",Nome="Otoniel", ProdutoDescricao="Burguesa",data=DateTime.Parse("2019-01-08")},
            new NotaFiscal{NotaFiscalID=2042,Tipo="CompraAPrazo",Observacao="Isento de Imposto",Nome="Navarro", ProdutoDescricao="Heineken",data=DateTime.Parse("2011-12-03")}
            };
            foreach (NotaFiscal c in notas)
            {
                context.NotasFiscais.Add(c);
            }
            context.SaveChanges();

            var produtos = new Produto[]
            {
            new Produto{ClienteID=1,NotaFiscalID=1050, descricao="Heineken"},
            new Produto{ClienteID=1,NotaFiscalID=4022, descricao="Heineken"},
            new Produto{ClienteID=1,NotaFiscalID=4041, descricao="Eisenbahn"},
            new Produto{ClienteID=2,NotaFiscalID=1045, descricao="Eisenbahn"},
            new Produto{ClienteID=2,NotaFiscalID=3141, descricao="Paulaner"},
            new Produto{ClienteID=2,NotaFiscalID=2021, descricao="Paulaner"},
            new Produto{ClienteID=3,NotaFiscalID=1050, descricao="Edgar"},
            new Produto{ClienteID=4,NotaFiscalID=1050, descricao="Edgar"},
            new Produto{ClienteID=4,NotaFiscalID=4022, descricao="Bohemia"},
            new Produto{ClienteID=5,NotaFiscalID=4041, descricao="Original"},
            new Produto{ClienteID=6,NotaFiscalID=1045, descricao="Burguesa"},
            new Produto{ClienteID=7,NotaFiscalID=3141, descricao="Burguesa"},
            };
            foreach (Produto e in produtos)
            {
                context.Produtos.Add(e);
            }
            context.SaveChanges();
        }
    }
}