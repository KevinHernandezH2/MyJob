using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJob.Models;
using System.Diagnostics;

namespace MyJob.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyJobDBContext _context; 

    
        public HomeController(ILogger<HomeController> logger, MyJobDBContext context)
        {
            _logger = logger;
            _context = context;

         
              
            

        }


        public IActionResult Index()
        {

            var empresas = _context.Empresas.ToListAsync();

            return View(empresas);

            


        }

        public IActionResult postulaciones()
        {
            return View();
        }

        public IActionResult MiUsuario()
        {
            return View();
        }

        public IActionResult Recursos()
        {
            return View();
        }

        public IActionResult Valoraciones()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}