using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesceUmaGeralada.Models;
using Microsoft.EntityFrameworkCore;
using DesceUmaGeralada.Dados;
using DesceUmaGeralada.Models.DesceUmaGeladaViewModels;

namespace DesceUmaGeralada.Controllers
{
    public class HomeController : Controller
    {

        private readonly BeerContext _context;

        public HomeController(BeerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<ProductDateGroup> data =
                from cliente in _context.Clientes
                group cliente by cliente.Produtos into dateGroup
                select new ProductDateGroup()
                {
                    ProdutoCount = dateGroup.Count(),
                    ClienteCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
