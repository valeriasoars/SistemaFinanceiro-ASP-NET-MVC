using System.Diagnostics;
using gerenciamento_financeiro_asp_net.Data;
using gerenciamento_financeiro_asp_net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_financeiro_asp_net.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Transacoes = _context.Transacoes.ToList();

            IQueryable<Financeiro> consulta = _context.Financas.Include(x => x.Transacao).Include(x => x.Categoria);

            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(c => c.CategoriaId == filtros.CategoriaId);
            };

            if(filtros.TemTransacao)
            {
                consulta = consulta.Where(c => c.TransacaoId == filtros.TransacaoId);
            };

            if(filtros.TemDataOperacao)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao < hoje);
                }

                if(filtros.EFuturo)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao > hoje);
                }

                if(filtros.EHoje)
                {
                    consulta = consulta.Where(c => c.DataDaOperacao ==  hoje);
                }
            };

            var financas = consulta.OrderBy(d => d.DataDaOperacao).ToList();


            return View(financas);
        }

     
    }
}
