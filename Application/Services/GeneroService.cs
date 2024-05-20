using Application.Repositorio;
using Application.ViewModels;
using DataBase;
using DataBase.Models;

namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;
        public GeneroService(ApplicationContext dbcontext)
        {
            _generoRepository = new(dbcontext);
        }

        public async Task<List<Generos>> GetAllGen()
        {
            var p = await _generoRepository.GetAllAsyncGen();
            var x = new List<Generos>();
            foreach (var item in p)
            {
                x.Add(new Generos()
                {
                    Id = item.GeneroId,
                    Nombre = item.Name,
                });
            }
            return x;
        }

        public async Task<string> GetGen(int id)
        {
            var p = await _generoRepository.GetByIdGen(id);
            return p.Name;
        }

        public async Task<List<GeneroViewModel>> GetAllGenViewModel()
        {
            var generoList = await _generoRepository.GetAllAsyncGen();

            return generoList.Select(g => new GeneroViewModel
            {
                GeneroId = g.GeneroId,
                Name = g.Name,
                ImageGenero = g.ImageGenero,
            }).ToList();
        }

        public async Task Add(SaveGeneroViewModel gm)
        {
            Genero g = new();

            g.Name = gm.Name;
            g.ImageGenero = gm.ImagePath;

            await _generoRepository.AddAsync(g);
        }

        public async Task Update(SaveGeneroViewModel gm)
        {
            Genero g = new();
            g.GeneroId = gm.Id;
            g.Name = gm.Name;
            g.ImageGenero = gm.ImagePath;

            await _generoRepository.UpdateAsync(g);
        }

        public async Task<SaveGeneroViewModel> GetByIdSaveViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdGen(id);
            SaveGeneroViewModel gm = new();

            gm.Id = genero.GeneroId;
            gm.Name = genero.Name;
            gm.ImagePath = genero.ImageGenero;

            return gm;
        }

        public async Task Delete(int id)
        {
            var genero = await _generoRepository.GetByIdGen(id);
            await _generoRepository.DeleteAsync(genero);
        }
    }
}
