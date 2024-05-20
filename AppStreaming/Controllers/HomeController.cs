using Application.Services;
using Application.ViewModels;
using AppStreaming.Models;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppStreaming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeriesServices _serieService;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public HomeController(ApplicationContext dbContext, ILogger<HomeController> logger)
        {
            _serieService = new(dbContext);
            _productoraService = new(dbContext);
            _generoService = new(dbContext);
        }
        public async Task<IActionResult> Index(FiltroViewModel vm)
        {
            ViewBag.Series = await _serieService.GetAllViewModelSeries();
            ViewBag.Productora = await _productoraService.GetAllViewModel();
            ViewBag.Genero = await _generoService.GetAllGenViewModel();
            return View(await _serieService.GetAllViewModelSeriesWithFilters(vm));
        }
    }
}
