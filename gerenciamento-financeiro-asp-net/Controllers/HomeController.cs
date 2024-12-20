using System.Diagnostics;
using gerenciamento_financeiro_asp_net.Models;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_financeiro_asp_net.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

     
    }
}
