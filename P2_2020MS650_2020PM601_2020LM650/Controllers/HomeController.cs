using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020MS650_2020PM601_2020LM650.Models;
using System.Diagnostics;

namespace P2_2020MS650_2020PM601_2020LM650.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly registro_covidDbContext _covidDbContext;
        public HomeController(ILogger<HomeController> logger, registro_covidDbContext registro_covidDbContext)
        {
            _logger = logger; 
            _covidDbContext = registro_covidDbContext;
        }
        

        public IActionResult Index()
        {
            var listaGeneros = (from g in _covidDbContext.genero
                                select g).ToList();
            ViewData["listaGeneros"] = new SelectList(listaGeneros, "id_genero", "nombregenero");

            var listaDep = (from d in _covidDbContext.departamento
                                select d).ToList();
            ViewData["listaDep"] = new SelectList(listaDep, "id_departamento", "nombredepartamento");

            var registroCovid = (from r in _covidDbContext.reporte
                                 join d in _covidDbContext.departamento on r.id_departamento equals d.id_departamento
                                 join g in _covidDbContext.genero on r.id_genero equals g.id_genero

                                 select new
                                 {
                                     departamento = d.nombredepartamento,
                                     genero = g.nombregenero,
                                     confirmados = r.confirmados,
                                     recuperados = r.recuperados,
                                     fallecidos = r.fallecidos,
            }).ToList();
            ViewData["registroCovid"] = registroCovid;

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