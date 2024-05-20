using Application.Repositorio;
using Application.ViewModels;
using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SeriesServices
    {
        private readonly SeriesRepository _serieRepository;

        public SeriesServices(ApplicationContext dbcontext)
        {
            _serieRepository = new(dbcontext);
        }

        #region View Home Page
        public async Task<List<SeriesViewModel>> GetAllViewModelSeries()
        {
            var seriesList = await _serieRepository.GetAllAsync();

            return seriesList.Select(s => new SeriesViewModel
            {
                Id = s.SerieId,
                Name = s.Titulo,
                Genero1 = s.Genero1.Name,
                Genero2 = s.Genero2?.Name,
                Productora = s.Productora.Nombre,
                ImagePath = s.ImagePath,
                DescriptionBreve = s.DescriptionBreve

            }).ToList();
        }

        #endregion

        #region Add Contenido
        public async Task Add(SaveSeriesViewModel vm)
        {
            Series series = new();
            series.Titulo = vm.Title;
            series.Info = vm.Info;
            series.DescriptionBreve = vm.DescriptionBreve;
            series.FechaDeSalida = vm.FechaSalida;
            series.ModeSerie = vm.ModeSerie;
            series.ProductoraId = vm.ProdId;
            series.Genero1Id = vm.GenId1;
            series.Genero2Id = vm.GenId2;
            series.ImagePath = vm.ImagePortada;
            series.VideoPAth = vm.VideoSerie;
            await _serieRepository.AddAsync(series);
        }
        #endregion

        #region Update Serie
        public async Task UpdateSerie(SaveSeriesViewModel vm)
        {
            Series series = new();
            series.SerieId = vm.Id;
            series.Titulo = vm.Title;
            series.Info = vm.Info;
            series.DescriptionBreve = vm.DescriptionBreve;
            series.FechaDeSalida = vm.FechaSalida;
            series.ModeSerie = vm.ModeSerie;
            series.ProductoraId = vm.ProdId;
            series.Genero1Id = vm.GenId1;
            series.Genero2Id = vm.GenId2;
            series.ImagePath = vm.ImagePortada;
            series.VideoPAth = vm.VideoSerie;
            await _serieRepository.UpdateAsync(series);
        }
        #endregion

        #region Delete Serie
        public async Task DeleteSeries(int id)
        {
            var series = await _serieRepository.GetById(id);
            await _serieRepository.DeleteAsync(series);
        }
        #endregion

        #region Get By Id SaveViewModel
        public async Task<SaveSeriesViewModel> GetByIdSaveViewModel(int id)
        {
            var series = await _serieRepository.GetById(id);

            SaveSeriesViewModel vm = new();
            vm.Id = series.SerieId;
            vm.Title = series.Titulo;
            vm.Info = series.Info;
            vm.DescriptionBreve = series.DescriptionBreve;
            vm.FechaSalida = series.FechaDeSalida;
            vm.ModeSerie = series.ModeSerie;
            vm.ProdId = series.ProductoraId;
            vm.GenId1 = series.Genero1Id;
            vm.GenId2 = series.Genero2Id;
            vm.ImagePortada = series.ImagePath;
            vm.VideoSerie = series.VideoPAth;

            return vm;
        }
        #endregion

        public async Task<ViewContenidoViewModel> GetViewContenido(int id)
        {
            var contenido = await _serieRepository.GetById(id);

            ViewContenidoViewModel vm = new();
            vm.Title = contenido.Titulo;
            vm.Info = contenido.Info;
            vm.FechaSalida = contenido.FechaDeSalida;
            vm.Gen1 = contenido.Genero1.Name;
            vm.ModeSerie = contenido.ModeSerie;
            vm.Gen2 = contenido.Genero2?.Name;
            vm.Prod = contenido.Productora.Nombre;
            vm.VideoSerie = contenido.VideoPAth;

            return vm;
        }

        public async Task<List<SeriesViewModel>> GetAllViewModelSeriesWithFilters(FiltroViewModel vm)
        {
            var seriesList = await _serieRepository.GetAllAsync();

            var list = seriesList.Select(s => new SeriesViewModel
            {
                Id = s.SerieId,
                Name = s.Titulo,
                Genero1 = s.Genero1.Name,
                Genero2 = s.Genero2?.Name,
                gn1ID = s.Genero1Id,
                gn2Id = s.Genero2Id,
                ModeSerie = s.ModeSerie,
                prodId = s.ProductoraId,
                Productora = s.Productora.Nombre,
                ImagePath = s.ImagePath,
                DescriptionBreve = s.DescriptionBreve

            }).ToList();

            if (vm.ProductoraId != null)
            {
                list = list.Where(p => p.prodId == vm.ProductoraId.Value).ToList();
                if (vm.GeneroId != null && vm.ProductoraId != null)
                {
                    list = list.Where(g => g.gn1ID == vm.GeneroId.Value && g.prodId == vm.ProductoraId.Value).ToList();
                    return list;
                }
                else
                {
                    return list;
                }
            }
            if (vm.GeneroId != null)
            {
                list = list.Where(g => g.gn1ID == vm.GeneroId.Value).ToList();
                return list; 
            }
            return list;
        }
    }
}
