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
    public class ProductoraService
    {
        private readonly ProductoraRepository _ProductoraRepository;
        public ProductoraService(ApplicationContext dbcontext)
        {
            _ProductoraRepository = new(dbcontext);
        }

        public async Task <List<ListProductoras>> GetAllProd()
        {
            var p = await _ProductoraRepository.GetAllAsyncProd();
            var x = new List<ListProductoras>();
            foreach (var item in p)
            {
                x.Add(new ListProductoras()
                {
                    Id = item.ProductoraId,
                    Nombre = item.Nombre,
                });
            }
            return x;
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoraList = await _ProductoraRepository.GetAllAsyncProd();
            return productoraList.Select(p => new ProductoraViewModel{
                ProductoraId = p.ProductoraId,
                Nombre = p.Nombre,
                Pais = p.Pais,
                AnioFundacion = p.AnioFundacion,
                ImageProd = p.ImageProd,

            }).ToList();
        }

        public async Task Add(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Nombre = vm.Nombre;
            productora.Pais = vm.Pais;
            productora.AnioFundacion = vm.AnioFundacion;
            productora.ImageProd = vm.ImageProd;

            await _ProductoraRepository.AddAsync(productora);
        }
        
        public async Task Update(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.ProductoraId = vm.ProductoraId;
            productora.Nombre = vm.Nombre;
            productora.Pais = vm.Pais;
            productora.AnioFundacion = vm.AnioFundacion;
            productora.ImageProd = vm.ImageProd;

            await _ProductoraRepository.UpdateAsync(productora);
        }

        public async Task<SaveProductoraViewModel> GetByIdSaveViewModel (int id)
        {
            var productora = await _ProductoraRepository.GetByIdProd(id);

            SaveProductoraViewModel vm = new();
            vm.ProductoraId = productora.ProductoraId;
            vm.AnioFundacion = productora.AnioFundacion;
            vm.Nombre = productora.Nombre;
            vm.ImageProd = productora.ImageProd;
            vm.Pais = productora.Pais;

            return vm;
        }

        public async Task Delete(int id)
        {
            var productora = await _ProductoraRepository.GetByIdProd(id);
            await _ProductoraRepository.DeleteAsync(productora);
        }
    }
}
