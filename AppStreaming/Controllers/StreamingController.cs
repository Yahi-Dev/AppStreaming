using Application.Services;
using Application.ViewModels;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace AppStreaming.Controllers
{
    public class StreamingController : Controller
    {
        private readonly SeriesServices _seriesServices;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public StreamingController(ApplicationContext applicationContext)
        {
            _seriesServices = new(applicationContext);
            _productoraService = new(applicationContext);
            _generoService = new(applicationContext);
        }

        #region Mant. Series

        #region Vista Index - Editar Y Borrar
        public async Task<IActionResult> Series()
        {
            return View(await _seriesServices.GetAllViewModelSeries());
        }
        #endregion

        #region Crear

        public async Task<IActionResult> CreateSeries()
        {
            SaveSeriesViewModel vm = new();
            vm.ListProductoras = await _productoraService.GetAllProd();
            vm.ListGeneros = await _generoService.GetAllGen();
            return View("SaveSeries", vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(SaveSeriesViewModel vm)
        {
            vm.ListProductoras = await _productoraService.GetAllProd();
            vm.ListGeneros = await _generoService.GetAllGen();

            if (!ModelState.IsValid)
            {
                return View("SaveSeries", vm);
            }
            await _seriesServices.Add(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Series" });
        }
        #endregion

        #region Vista Editar

        public async Task<IActionResult> EditSeries(int id)
        {
            var vm = await _seriesServices.GetByIdSaveViewModel(id);
            vm.ListProductoras = await _productoraService.GetAllProd();
            vm.ListGeneros = await _generoService.GetAllGen();
            return View("SaveSeries", vm);
        }


        [HttpPost]
        public async Task<IActionResult> EditSeries(SaveSeriesViewModel vm)
        {
            vm.ListProductoras = await _productoraService.GetAllProd();
            vm.ListGeneros = await _generoService.GetAllGen();
            if (!ModelState.IsValid)
            {
                return View("SaveSeries", vm);
            }
            await _seriesServices.UpdateSerie(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Series" });
        }

        #endregion

        #region Eliminar
        public async Task<IActionResult> DeleteSeries(int id)
        {
            return View(await _seriesServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeriesPost(int id)
        {
            await _seriesServices.DeleteSeries(id);
            return RedirectToRoute(new { controller = "Streaming", action = "Series" });
        }
        #endregion


        #region View Contenido
        public async Task<IActionResult> ViewContenido(int id)
        {
            var vm = await _seriesServices.GetViewContenido(id);
            return View("ViewContenido", vm);
        }


        #endregion

        #region ViewInfo
        public async Task<IActionResult> ViewInfo(int id)
        {
            var vm = await _seriesServices.GetViewContenido(id);
            return View(vm);
        }

        #endregion

        #endregion

        #region Mant. Generos
        public async Task<IActionResult> Generos()
        {
            return View(await _generoService.GetAllGenViewModel());
        }

        #region Create Genero
        public IActionResult CreateGen()
        {
            return View("SaveGenero", new SaveGeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGen(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }
            await _generoService.Add(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Generos" });
        }
        #endregion

        #region Editar Genero

        public async Task<IActionResult> EditGen(int id)
        {
            return View("SaveGenero", await _generoService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditGen (SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }
            await _generoService.Update(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Generos" });
        }
        #endregion

        #region Delete Genero
        public async Task<IActionResult> DeleteGen(int id)
        {
            return View(await _generoService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGenPost(int id)
        {
            await _generoService.Delete(id);
            return RedirectToRoute(new { controller = "Streaming", action = "Generos" });
        }

        #endregion

        #endregion

        #region Mant. Productora
        public async Task<IActionResult> Productora()
        {
            return View(await _productoraService.GetAllViewModel());
        }

        #region Create Productora
        public IActionResult CreateProd()
        {
            return View("SaveProd", new SaveProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProd(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProd", vm);
            }
            await _productoraService.Add(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Productora" });
        }
        #endregion

        #region Editar Productora
        public async Task<IActionResult> EditProd(int id)
        {
            return View("SaveProd", await _productoraService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditProd(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProd", vm);
            }
            await _productoraService.Update(vm);
            return RedirectToRoute(new { controller = "Streaming", action = "Productora" });
        }
        #endregion

        #region Delete Prodcutora
        public async Task<IActionResult> DeleteProd(int id)
        {
            var Prod = await _productoraService.GetByIdSaveViewModel(id);
            return View("DeleteProd", Prod);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProdPost(SaveProductoraViewModel vm)
        {
            await _productoraService.Delete(vm.ProductoraId);
            return RedirectToRoute(new { controller = "Streaming", action = "Productora" });
        }

        #endregion


        #endregion
    }
}