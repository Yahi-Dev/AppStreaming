using Application.ViewModels;
using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositorio
{
    public class GeneroRepository
    {
        private readonly ApplicationContext _DbContext;
        public GeneroRepository(ApplicationContext applicationContext)
        {
            _DbContext = applicationContext;
        }

        public async Task AddAsync(Genero genero)
        {
            await _DbContext.Genero.AddAsync(genero);
            await _DbContext.SaveChangesAsync();
        }

        //Editar
        public async Task UpdateAsync(Genero genero)
        {
            _DbContext.Entry(genero).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
        }


        //Borrar
        public async Task DeleteAsync(Genero genero)
        {
            _DbContext.Set<Genero>().Remove(genero);
            await _DbContext.SaveChangesAsync();
        }

        //Devolver todos los productos guardados
        public async Task<List<Genero>> GetAllAsyncGen()
        {
            return await _DbContext.Set<Genero>().ToListAsync();
        }

        public async Task<List<Generos>> GetAllIdAndNamesAsync()
        {
            var generos = await _DbContext.Set<Genero>()
                .Select(g => new Generos { Id = g.GeneroId, Nombre = g.Name })
                .ToListAsync();
            return generos;
        }

        public async Task<Genero> GetByIdGen(int id)
        {
            return await _DbContext.Set<Genero>().FindAsync(id);
        }
    }
}
