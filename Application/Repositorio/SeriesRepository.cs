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
    public class SeriesRepository
    {
        private readonly ApplicationContext _DbContext;

        public SeriesRepository(ApplicationContext applicationContext)
        {
            _DbContext = applicationContext;
        }

        public async Task AddAsync(Series series)
        {
            await _DbContext.Series.AddAsync(series);
            await _DbContext.SaveChangesAsync();
        }

        //Editar
        public async Task UpdateAsync(Series series)
        {
            _DbContext.Entry(series).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
        }



        //Borrar
        public async Task DeleteAsync(Series series)
        {
            _DbContext.Set<Series>().Remove(series);
            await _DbContext.SaveChangesAsync();
        }

        //Devolver todos los productos guardados
        public async Task<List<Series>> GetAllAsync()
        {
            return await _DbContext.Set<Series>().Include(s => s.Genero1).Include(s => s.Genero2).Include(p => p.Productora).ToListAsync();
        }

        public async Task<Series> GetById(int id)
        {
            return await _DbContext.Set<Series>().Include(s => s.Genero1).Include(s => s.Genero2).Include(p => p.Productora).FirstOrDefaultAsync(s => s.SerieId == id);
        }
    }
}
