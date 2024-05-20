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
    public class ProductoraRepository
    {
        private readonly ApplicationContext _DbContext;

        public ProductoraRepository(ApplicationContext applicationContext)
        {
            _DbContext = applicationContext;
        }

        public async Task AddAsync(Productora productora)
        {
            await _DbContext.Productora.AddAsync(productora);
            await _DbContext.SaveChangesAsync();
        }

        //Editar
        public async Task UpdateAsync(Productora productora)
        {
            _DbContext.Entry(productora).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
        }

        //Borrar
        public async Task DeleteAsync(Productora productora)
        {
            _DbContext.Set<Productora>().Remove(productora);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<ListProductoras>> GetAllProdIdAndNamesAsync()
        {
            var productora = await _DbContext.Set<Productora>()
                .Select(p => new ListProductoras { Id = p.ProductoraId, Nombre = p.Nombre })
                .ToListAsync();

            return productora;
        }

        //Devolver todos los productos guardados
        public async Task<List<Productora>> GetAllAsyncProd()
        {
            return await _DbContext.Set<Productora>().ToListAsync();
        }

        public async Task<Productora> GetByIdProd(int id)
        {
            return await _DbContext.Set<Productora>().FindAsync(id);
        }
    }
}
