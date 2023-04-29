using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2020MS650_2020PM601_2020LM650.Models;

namespace P2_2020MS650_2020PM601_2020LM650.Controllers
{
    public class registroController : Controller
    {
        private readonly registro_covidDbContext _covidDbContext;
        public registroController(registro_covidDbContext registro_covidDbContext) {
           _covidDbContext = registro_covidDbContext;
        }
        public IActionResult Index()
        {
            var listaGeneros = (from g in _covidDbContext.genero
                                  select g.nombregenero).ToList();
            ViewData["listaGeneros"] = new SelectList(listaGeneros, "nombregenero");

            return View();
        }
    }
}
